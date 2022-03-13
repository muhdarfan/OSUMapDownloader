using RestSharp;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Net.Sockets;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;

namespace OSUMapDownloader
{
    public partial class MainForm : Form
    {
        const string DOWNLOAD_LINK_1 = "https://chimu.moe/d";
        const string API_ENDPOINT = "https://osu.ppy.sh/api/v2/";

        private BindingList<BeatMap> _beatMapList, _localBeatMapList;

        private Thread _workingThread;

        static RestClient _client;
        private static HttpClient _httpClient, _downloadClient;

        private Stopwatch _sw = new Stopwatch();

        FileSystemWatcher _localFileWatcher;

        CancellationTokenSource src = new CancellationTokenSource();
        CancellationToken ct = new CancellationToken();

        private bool _running = true;
        private bool _stopRequested = false;

        public MainForm()
        {
            InitializeComponent();

            SocketsHttpHandler socketsHttpHandler = new SocketsHttpHandler()
            {
                ConnectCallback = async (context, cancellationToken) =>
                {
                    IPHostEntry ipHostEntry = await Dns.GetHostEntryAsync(context.DnsEndPoint.Host);

                    // Filter for IPv4 addresses only
                    IPAddress ipAddress = ipHostEntry
                        .AddressList
                        .FirstOrDefault(i => i.AddressFamily == AddressFamily.InterNetwork);

                    // Fail the connection if there aren't any IPV4 addresses
                    if (ipAddress == null)
                    {
                        throw new Exception($"No IP4 address for {context.DnsEndPoint.Host}");
                    }

                    // Open the connection to the target host/port
                    TcpClient tcp = new();
                    await tcp.ConnectAsync(ipAddress, context.DnsEndPoint.Port, cancellationToken);

                    // Return the NetworkStream to the caller
                    return tcp.GetStream();
                }
            };

            _client = new RestClient();
            _httpClient = new HttpClient(socketsHttpHandler);
            _downloadClient = new HttpClient(socketsHttpHandler);

            _httpClient.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("DotNet", "6"));


            System.Net.WebRequest.DefaultWebProxy = null;

            _beatMapList = new BindingList<BeatMap>();
            _localBeatMapList = new BindingList<BeatMap>();

            grid_localFiles.DataSource = _localBeatMapList;
            grid_remoteFiles.DataSource = _beatMapList;

            _localBeatMapList.ListChanged += _localBeatMapList_ListChanged;
            _beatMapList.ListChanged += _beatMapList_ListChanged;

            /*
            _localFileWatcher = new FileSystemWatcher($@"{Application.StartupPath}/download/");

            _localFileWatcher.Created += localFileWatcher_Event;
            _localFileWatcher.Changed += localFileWatcher_Event;
            _localFileWatcher.Deleted += localFileWatcher_Event;
            _localFileWatcher.Renamed += localFileWatcher_Event;
            */

        }

        private void _localBeatMapList_ListChanged(object? sender, ListChangedEventArgs e)
        {
            lock (grid_localFiles)
            {
                grid_localFiles.Refresh();
            }
        }

        private void localFileWatcher_Event(object sender, FileSystemEventArgs e)
        {
            try
            {
                String id = e.Name.Split(" ")[0];
                BeatMap map = new BeatMap(Int32.Parse(id));
                _localBeatMapList.Add(map);
            } catch
            {

            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            cb_mode.Items.AddRange(new string[]
            {
                "Any",
                "osu!",
                "osu!taiko",
                "osu!catch",
                "osu!mania"
            });
            cb_mode.SelectedIndex = 0;

            await LoadTestJson();
        }

        async Task LoadTestJson()
        {
            await Task.Run(async () =>
            {
                string apiJSON = await File.ReadAllTextAsync($@"{Application.StartupPath}\res.json");
                var res = JsonSerializer.Deserialize<BeatMapSetsResponse>(apiJSON)!;

                this.Invoke(() =>
                {
                    res.BeatMaps.ForEach(x => _beatMapList.Add(x));
                });
            });
        }

        private void _beatMapList_ListChanged(object? sender, ListChangedEventArgs e)
        {
            lock (grid_remoteFiles)
            {
                grid_remoteFiles.Refresh();
            }
        }

        private async void btn_find_Click(object sender, EventArgs e)
        {
            int stopAfter = 0;
            int mode = (cb_mode.SelectedIndex - 1);
            bool validNumber = int.TryParse(tb_findCount.Text, out stopAfter);

            if (validNumber)
            {
                _beatMapList.Clear();
                progressBar1.Value = 0;

                Log("Searching...");
                progressBar1.Value += 10;

                var task = Task.Run(async () =>
                {
                    String cursorString = "";

                    while (!_stopRequested && _beatMapList.Count < stopAfter)
                    {
                        var bmSets = await FetchBeatmap(txt_query.Text.Trim(), mode, cursorString);

                        if (bmSets == null)
                            break;

                        if (bmSets.BeatMaps == null || bmSets.BeatMaps.Count < 1)
                            break;

                        if (_beatMapList.Count > 0 && String.IsNullOrEmpty(bmSets.CursorString))
                            break;

                        cursorString = bmSets.CursorString!.ToString();
                        this.Invoke(() =>
                        {
                            bmSets.BeatMaps.ForEach(x => _beatMapList.Add(x));
                            progressBar1.Value += 100;
                        });
                    }
                });

                await task;

                lbl_total_fetched.Text = _beatMapList.Count.ToString();
                progressBar1.Value = 100;
                richTextBox1.Text += $"Fetched {_beatMapList.Count}... {Environment.NewLine}";

            }
            else
            {
                MessageBox.Show("Please enter a valid number for find maximum count.");
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_workingThread != null)
                _workingThread.Join();

            _httpClient.Dispose();
            _downloadClient.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                grid_remoteFiles.DataSource = new BindingList<BeatMap>(_beatMapList.Where(m => m.State != BeatMap.StateEnum.DOWNLOADED).ToList<BeatMap>());
            } else
            {
                grid_remoteFiles.DataSource = _beatMapList;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (_beatMapList.Count > 0)
            {
                _sw.Restart();
                Debug.WriteLine("Starting...");

                ct = src.Token;

                try
                {
                    /*
                    await Task.Run(() => Parallel.ForEach(strings, s =>
                    {
                        DoSomething(s);
                    }));
                    */

                    var options = new ParallelOptions { MaxDegreeOfParallelism = 2, CancellationToken = ct };
                    await Parallel.ForEachAsync(_beatMapList.Where(m => m.State != BeatMap.StateEnum.DOWNLOADED), options, async (song, token) =>
                    {
                        token.ThrowIfCancellationRequested();

                        song.State = BeatMap.StateEnum.DOWNLOADING;

                        this.Invoke(() =>
                        {
                            grid_remoteFiles.Refresh();
                        });

                        await Download(song);

                        song.State = BeatMap.StateEnum.DOWNLOADED;
                        this.Invoke(() =>
                        {
                            grid_remoteFiles.Refresh();
                        });
                    });

                    Debug.WriteLine("DONE DO");
                }
                catch (OperationCanceledException)
                {
                    MessageBox.Show("Operation cancelled");
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    src.Dispose();
                }

                _sw.Stop();
                Debug.WriteLine($"Done [Elapsed Time: {_sw.Elapsed.Seconds}]");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (src != null)
                src.Cancel();

            _stopRequested = true;
        }

        #region Method
        private void Log(string message, bool newLine = true)
        {
            richTextBox1.Text += $"[{DateTime.Now}] {message}" + (newLine ? Environment.NewLine : "");
        }

        async Task<BeatMapSetsResponse?> FetchBeatmap(string query = "", int mode = -1, string? cursor = "", CancellationToken cancellationToken = default)
        {
            BeatMapSetsResponse? res = null;

            var builder = new UriBuilder("https://osu.ppy.sh/beatmapsets/search");
            builder.Port = -1;

            var param = HttpUtility.ParseQueryString(builder.Query);
            param["q"] = query;

            if (mode != -1)
                param["m"] = mode.ToString();

            if (!String.IsNullOrEmpty(cursor))
                param["cursor_string"] = cursor;

            builder.Query = param.ToString();

            var response = await _httpClient.GetAsync(builder.Uri);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                res = JsonSerializer.Deserialize<BeatMapSetsResponse>(apiResponse)!;
            }

            return res;
        }

        private async Task Download(BeatMap map)
        {

            this.Invoke(() =>
            {
                richTextBox1.Text += $"Downloading [{map.Id}] {map.Title} on Thread {Thread.CurrentThread.ManagedThreadId} {Environment.NewLine}";
                Debug.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] Downloading {map.Title}...");
                Debug.WriteLine($@"{Application.StartupPath}/download/{map.Id} {map.Artist} - {map.Title}.osz");
            });
            map.State = BeatMap.StateEnum.DOWNLOADING;

            var responseStream = await _downloadClient.GetStreamAsync($"{DOWNLOAD_LINK_1}/{map.Id}");
            using var fileStream = new FileStream($@"{Application.StartupPath}/download/{map.Id} {map.Artist} - {map.Title}.osz", FileMode.Create);
            responseStream.CopyTo(fileStream);

            map.State = BeatMap.StateEnum.DOWNLOADED;

            this.Invoke(() =>
            {
                Debug.WriteLine($"[{map.Id}] Done");
            });
        }

        #endregion
    }

    #region SubClass

    public class BeatMapSetsResponse
    {
        [JsonPropertyName("beatmapsets")]
        public List<BeatMap>? BeatMaps { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("cursor_string")]
        public string? CursorString { get; set; }
    }


    public class BeatMap
    {
        public enum StateEnum
        {
            WAITING,
            DOWNLOADING,
            DOWNLOADED
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("artist")]
        [System.ComponentModel.Browsable(false)]
        public string? Artist { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }
        public StateEnum State { get; set; } = StateEnum.WAITING;

        public BeatMap(int id)
        {
            Id = id;
        }
    }
    #endregion
}