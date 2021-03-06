using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Web;

namespace OSUMapDownloader
{
    public partial class MainForm : Form
    {
        const string API_CLIENT_ID = "CLIENT_ID"; // PLEASE CHANGE THIS ACCORDING TO YOUR APP KEY
        const string API_CLIENT_SECRET = "CLIENT_SECRET"; // PLEASE CHANGE THIS ACCORDING TO YOUR APP KEY

        const string DOWNLOAD_LINK_1 = "https://chimu.moe/d";
        const string DOWNLOAD_LINK_2 = "https://beatconnect.io/b/";
        const string DOWNLOAD_LINK_3 = "https://api.nerina.pw/d";
        const string DOWNLOAD_LINK_4 = "https://dl.sayobot.cn/beatmaps/download/full/id";
        const string DOWNLOAD_LINK_5 = "https://dl.sayobot.cn/beatmaps/download/novideo/";

        const string API_ENDPOINT = "https://osu.ppy.sh/api/v2/";
        static Uri oauthURI = new Uri($"https://osu.ppy.sh/oauth/authorize?client_id={API_CLIENT_ID}&redirect_uri=http://localhost:31170/&response_type=code&scope=public");
        static Uri tokenURI = new Uri("https://osu.ppy.sh/oauth/token");

        private DateTime _lastTimeFileWatch;

        private List<string> _downloadMirrorLink = new List<string>()
        {
            DOWNLOAD_LINK_1,
            DOWNLOAD_LINK_3,
            DOWNLOAD_LINK_5,
            DOWNLOAD_LINK_2,
        };
        private BindingList<BeatMap> _beatMapList, _localBeatMapList;

        private static HttpClient? _httpClient, _downloadClient;
        private static HttpListener? _httpListener;

        private Stopwatch _sw = new Stopwatch();

        private FileSystemWatcher _localFileWatcher;

        private CancellationTokenSource src;

        private CookieContainer cookies = new CookieContainer();

        private OsuSettings _config = new OsuSettings();

        private bool _isRunning = false;
        private bool _stopRequested = false;

        private object _gridLocalLock = new object();
        private object _padLock = new object();

        public MainForm()
        {
            InitializeComponent();

            Directory.CreateDirectory(Path.Combine(Application.StartupPath, "download"));

            SocketsHttpHandler socketsHttpHandler = new SocketsHttpHandler()
            {
                ConnectCallback = async (context, cancellationToken) =>
                {
                    IPHostEntry ipHostEntry = await Dns.GetHostEntryAsync(context.DnsEndPoint.Host);

                    // Filter for IPv4 addresses only
                    IPAddress? ipAddress = ipHostEntry.AddressList.FirstOrDefault(i => i.AddressFamily == AddressFamily.InterNetwork);

                    // Fail the connection if there aren't any IPV4 addresses
                    if (ipAddress == null)
                        throw new Exception($"No IP4 address for {context.DnsEndPoint.Host}");

                    // Open the connection to the target host/port
                    TcpClient tcp = new();
                    await tcp.ConnectAsync(ipAddress, context.DnsEndPoint.Port, cancellationToken);

                    // Return the NetworkStream to the caller
                    return tcp.GetStream();
                },
                AllowAutoRedirect = true,
                UseCookies = true,
                CookieContainer = cookies
            };

            _httpClient = new HttpClient(socketsHttpHandler);
            _downloadClient = new HttpClient(socketsHttpHandler);

            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.51 Safari/537.36");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _config.token!.AccessToken!);

            _downloadClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.51 Safari/537.36");

            System.Net.WebRequest.DefaultWebProxy = null;

            _beatMapList = new BindingList<BeatMap>();
            _localBeatMapList = new BindingList<BeatMap>();

            grid_localFiles.AutoGenerateColumns = false;
            grid_remoteFiles.AutoGenerateColumns = false;

            grid_localFiles.DataSource = _localBeatMapList;
            grid_remoteFiles.DataSource = _beatMapList;

            _localFileWatcher = new FileSystemWatcher(_config.saveLocationPath!);

            _localFileWatcher.EnableRaisingEvents = _config.enableFileWatch;
            _localFileWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.DirectoryName;
            //_localFileWatcher.SynchronizingObject = this;
            _localFileWatcher.Filter = "*.osz";

            _localFileWatcher.Created += localFileWatcher_Event;
            _localFileWatcher.Changed += localFileWatcher_Event;
            _localFileWatcher.Deleted += localFileWatcher_Event;
            _localFileWatcher.Renamed += localFileWatcher_Event;
        }

        private void MainForm_Load(object sender, EventArgs e)
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

            _config.SettingsSaving += _config_SettingsSaving;

            tb_saveLocationPath.Text = _config.saveLocationPath;
            tb_token.Text = _config.token?.AccessToken! ?? "";

            cb_enableWatch.Checked = _config.enableFileWatch;
            cb_hideDownloaded.Checked = _config.hideDownloaded;
            RefreshLocalSong();
        }

        private void _config_SettingsSaving(object sender, CancelEventArgs e)
        {
            _httpClient!.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _config.token!.AccessToken!);
        }

        private void localFileWatcher_Event(object sender, FileSystemEventArgs e)
        {
            if (_isRunning)
                return;

            RefreshLocalSong();

            /*
            if (DateTime.Now.Subtract(_lastTimeFileWatch).TotalMilliseconds < 500 || _isRunning)
                return;

            _lastTimeFileWatch = DateTime.Now;
            */
        }

        private async void btn_find_Click(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                _stopRequested = true;

                btn_find.Enabled = false;
                Log("Stopping....");
                src.Cancel();

                return;
            }

            int stopAfter = 0;
            int mode = (cb_mode.SelectedIndex - 1);
            bool validNumber = int.TryParse(tb_findCount.Text, out stopAfter);

            if (validNumber)
            {
                try
                {
                    SetInputEnabled(false);
                    btn_find.Text = "Stop";

                    btn_startStop.Enabled = false;
                    btn_generateToken.Enabled = false;
                    btn_exit.Enabled = false;

                    _beatMapList.Clear();
                    progressBar1.Value = 0;

                    src = new CancellationTokenSource();
                    var ct = src.Token;

                    if (!_localFileWatcher.EnableRaisingEvents)
                        RefreshLocalSong();

                    Log("Searching...");
                    _isRunning = true;
                    progressBar1.Value += 10;

                    await Task.Run(async () =>
                    {
                        String cursorString = "";
                        int percentComplete = 0;

                        while (!_stopRequested && _beatMapList.Count < stopAfter)
                        {
                            var bmSets = await FetchBeatmap(txt_query.Text.Trim(), mode, cursorString, ct);

                            if (bmSets == null)
                                break;

                            if (bmSets.BeatMaps == null || bmSets.BeatMaps.Count < 1)
                                break;

                            ct.ThrowIfCancellationRequested();

                            this.Invoke(() =>
                            {
                                foreach(var bm in bmSets.BeatMaps)
                                {
                                    if (_beatMapList.Count >= stopAfter)
                                        break;

                                    if (cb_hideDownloaded.Checked && _localBeatMapList.Any(item => item.Id == bm.Id))
                                        continue;

                                    if (_localBeatMapList.Any(item => item.Id == bm.Id))
                                        bm.State = BeatMap.StateEnum.DOWNLOADED;

                                    _beatMapList.Add(bm);
                                }
                                percentComplete = (int)Math.Round((double)(90 * _beatMapList.Count) / stopAfter);

                                progressBar1.Value = percentComplete;
                            });

                            if (String.IsNullOrEmpty(bmSets.CursorString))
                                break;
                            
                            cursorString = bmSets.CursorString!.ToString();
                        }
                    }, ct);
                }
                catch (OperationCanceledException) 
                {
                    MessageBox.Show("Operation cancelled");
                    Log("Operation cancelled.");
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"HTTPRequest Error\n\nStatus Code: {ex.StatusCode}\n\nPlease check your access token!", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An Exception has been occurred! Please report to Admin!", "Exception");

                    Debug.WriteLine(ex.Message);
                }
                finally
                {
                    SetInputEnabled();
                    progressBar1.Value = 100;

                    _isRunning = false;
                    _stopRequested = false;

                    btn_find.Enabled = true;
                    btn_startStop.Enabled = true;
                    btn_exit.Enabled = true;
                    btn_generateToken.Enabled = true;

                    btn_find.Text = "Find";

                    lbl_total_fetched.Text = _beatMapList.Count.ToString();
                    Log($"Fetched {_beatMapList.Count}/{stopAfter} songs ...");

                    src.Dispose();
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number for find maximum count.");
            }
        }

        private async void btn_startStop_Click(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                _stopRequested = true;
                btn_startStop.Enabled = false;

                Log("Stopping...");
                src.Cancel();

                return;
            }

            if (_beatMapList.Count > 0 && _beatMapList.Any(item => item.State != BeatMap.StateEnum.DOWNLOADED))
            {
                int count = 0;
                int worker = (int)tb_workerCount.Value;

                _isRunning = true;
                _stopRequested = false;

                btn_find.Enabled = false;
                btn_generateToken.Enabled = false;
                btn_exit.Enabled = false;

                btn_startStop.Text = "Stop";
                SetInputEnabled(false);

                progressBar1.Value = 5;

                _sw.Restart();
                Log("\r\nStarting...");

                src = new CancellationTokenSource();

                try
                {
                    IList<BeatMap> downloadList = _beatMapList.Where(m => m.State != BeatMap.StateEnum.DOWNLOADED).ToList();
                    var options = new ParallelOptions { MaxDegreeOfParallelism = worker, CancellationToken = src.Token };
                    int percentComplete = 0;

                    await Parallel.ForEachAsync(downloadList, options, async (song, token) =>
                    {
                        token.ThrowIfCancellationRequested();

                        var flag = await Download(song, token);

                        if (flag)
                            count++;

                        this.Invoke(() =>
                        {
                            percentComplete = (int)Math.Round((double)(90 * count) / downloadList.Count);
                            progressBar1.Value = percentComplete;
                        });
                        
                    });
                }
                catch (OperationCanceledException)
                {
                    MessageBox.Show("Operation cancelled");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"[ERROR] {ex.Message}");
                }
                finally
                {
                    _isRunning = false;
                    _stopRequested = false;

                    btn_startStop.Text = "Start";
                    btn_startStop.Enabled = true;
                    btn_find.Enabled = true;
                    btn_generateToken.Enabled = true;
                    btn_exit.Enabled = true;

                    SetInputEnabled();
                    _sw.Stop();

                    progressBar1.Value = 100;
                    MessageBox.Show($"Downloaded {count} songs.");
                    Log($"Downloaded {count} songs [Elapsed Time: {_sw.Elapsed.Seconds} seconds]");

                    RefreshLocalSong();

                    src.Dispose();
                }
            }
            else
            {
                MessageBox.Show("There's no song to be downloaded.");
            }
        }

        private async void btn_generateToken_Click(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                _stopRequested = true;
                btn_generateToken.Enabled = false;

                _httpListener!.Stop();
                _httpListener!.Abort();
                _httpListener!.Close();

                Log("Cancelling...");
                src.Cancel();

                return;
            }

            try
            {
                _isRunning = true;

                btn_generateToken.Text = "Cancel";
                btn_exit.Enabled = false;
                btn_find.Enabled = false;
                btn_startStop.Enabled = false;
                SetInputEnabled(false);

                String? code;

                src = new CancellationTokenSource();
                var ct = src.Token;

                await Task.Run(async () =>
                {
                    _httpListener = new HttpListener();
                    Log("Generating token...");
                    _httpListener.Prefixes.Add("http://localhost:31170/");
                    _httpListener.Start();

                    var process = new Process();
                    process.StartInfo.FileName = oauthURI.ToString();
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.Verb = "";
                    process.Start();

                    var context = await _httpListener.GetContextAsync();
                    var response = context.Response;

                    code = context.Request.QueryString.Get("code");

                    string responseString = "<html><head></head><body>You are succesfully connected. You may close this tab and open back the application.</body></html>";
                    var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                    response.ContentLength64 = buffer.Length;
                    var responseOutput = response.OutputStream;

                    Task responseTask = responseOutput.WriteAsync(buffer, 0, buffer.Length, ct).ContinueWith((task) =>
                    {
                        responseOutput.Close();
                        _httpListener.Stop();
                        _httpListener.Close();
                    });

                    if (String.IsNullOrEmpty(code))
                    {
                        this.Invoke(() => MessageBox.Show("Authorization failed!\n\nNo code present!", "Authorization Failed", MessageBoxButtons.OK, MessageBoxIcon.Error));
                        Log("Authorization failed! No code present");
                        return;
                    }

                    ct.ThrowIfCancellationRequested();

                    Log("Retrieving access token...");

                    var formContent = new FormUrlEncodedContent(new Dictionary<string, string> {
                            { "client_id", API_CLIENT_ID },
                            { "client_secret", API_CLIENT_SECRET },
                            { "grant_type", "authorization_code" },
                            { "code", code },
                            { "redirect_uri", "http://localhost:31170/" }
                       });

                    var osuResponse = await _httpClient!.PostAsync(tokenURI, formContent, ct);
                    osuResponse.EnsureSuccessStatusCode();

                    string apiResponse = await osuResponse.Content.ReadAsStringAsync(ct);

                    this.Invoke(() =>
                    {
                        _config.token = JsonSerializer.Deserialize<Token>(apiResponse)!;
                        _config.Save();

                        tb_token.Text = _config.token.AccessToken;

                        Log("Access token granted!");
                        MessageBox.Show("Access token has been successfully generated!");
                    });
                }, ct);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"HTTPRequest Error\n\nStatus Code: {ex.StatusCode}\n\nMessage: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OperationCanceledException)
            {
                Log("Authorization failed due to cancellation");
                MessageBox.Show("Operation cancelled");
            }
            catch (HttpListenerException)
            {
                Log("Authorization failed due to cancellation");
                MessageBox.Show("Operation cancelled");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected Error\n\nMessage: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isRunning = false;
                _stopRequested = false;

                btn_generateToken.Text = "Generate";

                btn_exit.Enabled = true;
                btn_find.Enabled = true;
                btn_startStop.Enabled = true;
                btn_generateToken.Enabled = true;

                SetInputEnabled();

                src.Dispose();
            }
        }

        private void btn_changeSaveLocationPath_Click(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                MessageBox.Show("Operation disabled when task is running.");
                return;
            }

            using (var fbd = new FolderBrowserDialog())
            {
                fbd.InitialDirectory = Application.StartupPath;
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    _config.saveLocationPath = fbd.SelectedPath;
                    tb_saveLocationPath.Text = _config.saveLocationPath;

                    _localFileWatcher.Path = fbd.SelectedPath;
                    RefreshLocalSong();
                }
            }
        }

        private void btn_clearLog_Click(object sender, EventArgs e)
        {
            rtb_logBox.Text = "";
        }

        private void tb_token_Leave(object sender, EventArgs e)
        {
            _config.token!.AccessToken = tb_token.Text;
            _config.Save();
        }

        private void tb_token_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.ActiveControl = null;
        }

        private void btn_about_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_httpClient != null)
                _httpClient!.Dispose();

            if (_downloadClient != null)
                _downloadClient!.Dispose();

            if (_localFileWatcher != null)
                _localFileWatcher.Dispose();

            _config.Save();
        }

        private void cmBtn_grid_local_refresh_Click(object sender, EventArgs e)
        {
            RefreshLocalSong();
        }

        private void cb_enableWatch_CheckedChanged(object sender, EventArgs e)
        {
            _config.enableFileWatch = cb_enableWatch.Checked;
            _localFileWatcher.EnableRaisingEvents = cb_enableWatch.Checked;

            if (cb_enableWatch.Checked)
                RefreshLocalSong();
        }

        #region Method
        private void Log(string message = "", bool newLine = true)
        {
            if (String.IsNullOrEmpty(message))
                rtb_logBox.Text += Environment.NewLine;

            String text = $"[{DateTime.Now}] {message}" + (newLine ? Environment.NewLine : "");

            this.Invoke(() => rtb_logBox.Text += text);

            lock (_padLock)
                File.AppendAllText(Path.Combine(Application.StartupPath, $"log-{DateTime.Now.ToString("yyyyMMdd")}.txt"), text);
        }

        private void SetInputEnabled(bool enabled = true)
        {
            this.txt_query.Enabled = enabled;
            this.cb_mode.Enabled = enabled;
            this.tb_findCount.Enabled = enabled;
            this.tb_token.Enabled = enabled;
            this.tb_findCount.Enabled = enabled;
            this.tb_workerCount.Enabled = enabled;
            this.cb_hideDownloaded.Enabled = enabled;
            this.cb_enableWatch.Enabled = enabled;
            this.btn_changeSaveLocationPath.Enabled = enabled;
        }

        private void RefreshLocalSong()
        {
            var songs = new DirectoryInfo(_config.saveLocationPath!).GetFileSystemInfos();
            var songInfos = new List<BeatMap>();

            foreach (var song in songs)
            {
                // Debug.WriteLine($"FOUND {song.Name}");
                var parts = song.Name.Split(' ');

                // Check if start with number
                if (!Regex.IsMatch(parts[0], "^[0-9]+$"))
                    continue;

                int id = int.Parse(parts[0]);
                string? name = parts.Length > 1 ? song.Name.Substring(parts[0].Length + 1) : null;

                // Remove extension
                if (!string.IsNullOrEmpty(song.Extension) && song.Extension == ".osz")
                    name = name!.Substring(0, name.Length - 4);

                songInfos.Add(new BeatMap(id, name));
            }

            lock (_gridLocalLock)
            {
                this.Invoke(() =>
                {
                    _localBeatMapList.Clear();
                    songInfos.ForEach(x => _localBeatMapList.Add(x));
                });
            }
        }

        private void cb_hideDownloaded_CheckedChanged(object sender, EventArgs e)
        {
            _config.hideDownloaded = cb_hideDownloaded.Checked;
        }

        private void rtb_logBox_TextChanged(object sender, EventArgs e)
        {
            rtb_logBox.SelectionStart = rtb_logBox.Text.Length;
            rtb_logBox.ScrollToCaret();
        }

        async Task<BeatMapSetsResponse?> FetchBeatmap(string query = "", int mode = -1, string? cursor = "", CancellationToken cancellationToken = default)
        {
            BeatMapSetsResponse? res = null;

            var builder = new UriBuilder(API_ENDPOINT + "beatmapsets/search");
            builder.Port = -1;

            var param = HttpUtility.ParseQueryString(builder.Query);
            param["q"] = query;

            if (mode != -1)
                param["m"] = mode.ToString();

            if (!String.IsNullOrEmpty(cursor))
                param["cursor_string"] = cursor;

            builder.Query = param.ToString();

            var response = await _httpClient!.GetAsync(builder.Uri, cancellationToken);
            response.EnsureSuccessStatusCode();

            cancellationToken.ThrowIfCancellationRequested();

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                res = JsonSerializer.Deserialize<BeatMapSetsResponse>(apiResponse)!;
            }

            return res;
        }

        private async Task<bool> Download(BeatMap map, CancellationToken token = default)
        {
            var dLMirror = new Queue<string>(_downloadMirrorLink);
            int attempt = 1;
            int mirrorCount = _downloadMirrorLink.Count;

            while (dLMirror.Any() && !token.IsCancellationRequested)
            {
                token.ThrowIfCancellationRequested();

                try
                {
                    var link = dLMirror.Dequeue();

                    map.State = BeatMap.StateEnum.DOWNLOADING;

                    this.Invoke(() =>
                    {
                        Log($"Downloading [{map.Id}] {map.Title} (Attempt #{attempt}/{mirrorCount})");
                        //Debug.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] Downloading {map.Title}...");
                        //Debug.WriteLine($@"{Application.StartupPath}/download/{map.Id} {map.Artist} - {map.Title}.osz");
                    });

                    var responseStream = await _downloadClient!.GetStreamAsync($"{link}/{map.Id}", token);

                    using var fileStream = new FileStream($@"{_config.saveLocationPath}/{map.GetSongFileName()}", FileMode.Create);
                    await responseStream.CopyToAsync(fileStream, token);

                    if (((double)fileStream.Length / 1024) < 100)
                        throw new FileFormatException("Invalid file size! < 100Kb");

                    map.State = BeatMap.StateEnum.DOWNLOADED;

                    return true;
                }
                catch (Exception ex)
                {
                    map.State = BeatMap.StateEnum.FAILED;

                    if (ex is OperationCanceledException || ex is TaskCanceledException)
                    {
                        if (File.Exists($@"{_config.saveLocationPath}/{map.GetSongFileName()}"))
                            File.Delete($@"{_config.saveLocationPath}/{map.GetSongFileName()}");
                    }
                    else
                    {
                        if (ex is FileFormatException && File.Exists($@"{_config.saveLocationPath}/{map.GetSongFileName()}"))
                            File.Delete($@"{_config.saveLocationPath}/{map.GetSongFileName()}");

                        this.Invoke(() =>
                        {
                            Log($"[ERROR] Failed to download {map.GetSongFileName()}. (Message: {ex.Message})");
                            Log("Delaying 5 seconds before continuing...");
                        });

                        attempt++;
                        await Task.Delay(TimeSpan.FromSeconds(5), token);
                    }
                }
            }

            return false;
        }

        #endregion
    }

    #region SubClass
    [Serializable]
    public class Token
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("expires_in")]
        public int? ExpiresIn { get; set; }

        [JsonPropertyName("refresh_token")]
        public string? RefreshToken { get; set; }

        [JsonPropertyName("token_type")]
        public string? TokenType { get; set; }
    }

    public class BeatMapSetsResponse
    {
        [JsonPropertyName("beatmapsets")]
        public List<BeatMap>? BeatMaps { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("cursor_string")]
        public string? CursorString { get; set; }
    }


    public class BeatMap : INotifyPropertyChanged
    {
        private StateEnum _state = StateEnum.WAITING;
        public enum StateEnum
        {
            WAITING,
            DOWNLOADING,
            FAILED,
            DOWNLOADED
        }

        [JsonPropertyName("id")]
        [System.ComponentModel.DisplayName("ID")]
        public int Id { get; set; }

        [JsonPropertyName("artist")]
        [System.ComponentModel.Browsable(false)]
        public string? Artist { get; set; }

        [JsonPropertyName("title")]
        [System.ComponentModel.DisplayName("Title")]
        public string? Title { get; set; }

        [DisplayName("State")]
        public StateEnum State
        {
            get => _state; 
            set
            {
                _state = value;
                this.NotifyPropertyChanged("State");
            }
        }

        public BeatMap(int id, string? title)
        {
            Id = id;
            Title = title;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public String GetSongFileName()
        {
            var fileName =  $"{Id} {Title}.osz";
            fileName = string.Join("-", fileName.Split(Path.GetInvalidFileNameChars()));

            return fileName;
        }

        private void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    #endregion
}
