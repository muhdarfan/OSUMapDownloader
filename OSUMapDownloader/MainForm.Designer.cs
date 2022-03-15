namespace OSUMapDownloader
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btn_exit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_generateToken = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_token = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_mode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_findCount = new System.Windows.Forms.TextBox();
            this.btn_startStop = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_find = new System.Windows.Forms.Button();
            this.txt_query = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grid_localFiles = new System.Windows.Forms.DataGridView();
            this.grid_localFiles_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_localFiles_title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cm_grid_local = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmBtn_grid_local_refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.grid_remoteFiles = new System.Windows.Forms.DataGridView();
            this.grid_remoteFiles_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_remoteFiles_title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_remoteFiles_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtb_logBox = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbl_total_fetched = new System.Windows.Forms.Label();
            this.btn_clearLog = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_about = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_workerCount = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_changeSaveLocationPath = new System.Windows.Forms.Button();
            this.tb_saveLocationPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_localFiles)).BeginInit();
            this.cm_grid_local.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_remoteFiles)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_workerCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(778, 533);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 1;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_generateToken);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tb_token);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cb_mode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_findCount);
            this.groupBox1.Controls.Add(this.btn_startStop);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_find);
            this.groupBox1.Controls.Add(this.txt_query);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 113);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btn_generateToken
            // 
            this.btn_generateToken.Location = new System.Drawing.Point(348, 83);
            this.btn_generateToken.Name = "btn_generateToken";
            this.btn_generateToken.Size = new System.Drawing.Size(75, 23);
            this.btn_generateToken.TabIndex = 11;
            this.btn_generateToken.Text = "Generate";
            this.btn_generateToken.UseVisualStyleBackColor = true;
            this.btn_generateToken.Click += new System.EventHandler(this.btn_generateToken_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Token";
            // 
            // tb_token
            // 
            this.tb_token.Location = new System.Drawing.Point(87, 84);
            this.tb_token.Name = "tb_token";
            this.tb_token.Size = new System.Drawing.Size(255, 23);
            this.tb_token.TabIndex = 9;
            this.tb_token.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_token_KeyUp);
            this.tb_token.Leave += new System.EventHandler(this.tb_token_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mode";
            // 
            // cb_mode
            // 
            this.cb_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_mode.FormattingEnabled = true;
            this.cb_mode.Location = new System.Drawing.Point(87, 51);
            this.cb_mode.Name = "cb_mode";
            this.cb_mode.Size = new System.Drawing.Size(137, 23);
            this.cb_mode.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "map";
            // 
            // tb_findCount
            // 
            this.tb_findCount.Location = new System.Drawing.Point(299, 51);
            this.tb_findCount.Name = "tb_findCount";
            this.tb_findCount.Size = new System.Drawing.Size(87, 23);
            this.tb_findCount.TabIndex = 5;
            this.tb_findCount.Text = "100";
            // 
            // btn_startStop
            // 
            this.btn_startStop.Location = new System.Drawing.Point(429, 83);
            this.btn_startStop.Name = "btn_startStop";
            this.btn_startStop.Size = new System.Drawing.Size(102, 23);
            this.btn_startStop.TabIndex = 4;
            this.btn_startStop.Text = "Start";
            this.btn_startStop.UseVisualStyleBackColor = true;
            this.btn_startStop.Click += new System.EventHandler(this.btn_startStop_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Stop after:";
            // 
            // btn_find
            // 
            this.btn_find.Location = new System.Drawing.Point(429, 50);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(102, 23);
            this.btn_find.TabIndex = 2;
            this.btn_find.Text = "Find";
            this.btn_find.UseVisualStyleBackColor = true;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // txt_query
            // 
            this.txt_query.Location = new System.Drawing.Point(87, 22);
            this.txt_query.Name = "txt_query";
            this.txt_query.Size = new System.Drawing.Size(444, 23);
            this.txt_query.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // grid_localFiles
            // 
            this.grid_localFiles.AllowUserToAddRows = false;
            this.grid_localFiles.AllowUserToDeleteRows = false;
            this.grid_localFiles.AllowUserToResizeRows = false;
            this.grid_localFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_localFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_localFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grid_localFiles_id,
            this.grid_localFiles_title});
            this.grid_localFiles.ContextMenuStrip = this.cm_grid_local;
            this.grid_localFiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid_localFiles.Location = new System.Drawing.Point(12, 131);
            this.grid_localFiles.MultiSelect = false;
            this.grid_localFiles.Name = "grid_localFiles";
            this.grid_localFiles.ReadOnly = true;
            this.grid_localFiles.RowHeadersVisible = false;
            this.grid_localFiles.RowTemplate.Height = 25;
            this.grid_localFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_localFiles.Size = new System.Drawing.Size(255, 396);
            this.grid_localFiles.TabIndex = 4;
            // 
            // grid_localFiles_id
            // 
            this.grid_localFiles_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.grid_localFiles_id.DataPropertyName = "ID";
            this.grid_localFiles_id.FillWeight = 81.21828F;
            this.grid_localFiles_id.HeaderText = "ID";
            this.grid_localFiles_id.Name = "grid_localFiles_id";
            this.grid_localFiles_id.ReadOnly = true;
            this.grid_localFiles_id.Width = 43;
            // 
            // grid_localFiles_title
            // 
            this.grid_localFiles_title.DataPropertyName = "Title";
            this.grid_localFiles_title.FillWeight = 118.7817F;
            this.grid_localFiles_title.HeaderText = "Title";
            this.grid_localFiles_title.Name = "grid_localFiles_title";
            this.grid_localFiles_title.ReadOnly = true;
            // 
            // cm_grid_local
            // 
            this.cm_grid_local.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmBtn_grid_local_refresh});
            this.cm_grid_local.Name = "contextMenuStrip1";
            this.cm_grid_local.Size = new System.Drawing.Size(114, 26);
            // 
            // cmBtn_grid_local_refresh
            // 
            this.cmBtn_grid_local_refresh.Name = "cmBtn_grid_local_refresh";
            this.cmBtn_grid_local_refresh.Size = new System.Drawing.Size(113, 22);
            this.cmBtn_grid_local_refresh.Text = "Refresh";
            this.cmBtn_grid_local_refresh.Click += new System.EventHandler(this.cmBtn_grid_local_refresh_Click);
            // 
            // grid_remoteFiles
            // 
            this.grid_remoteFiles.AllowUserToAddRows = false;
            this.grid_remoteFiles.AllowUserToDeleteRows = false;
            this.grid_remoteFiles.AllowUserToResizeRows = false;
            this.grid_remoteFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_remoteFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_remoteFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grid_remoteFiles_id,
            this.grid_remoteFiles_title,
            this.grid_remoteFiles_state});
            this.grid_remoteFiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid_remoteFiles.Location = new System.Drawing.Point(273, 131);
            this.grid_remoteFiles.MultiSelect = false;
            this.grid_remoteFiles.Name = "grid_remoteFiles";
            this.grid_remoteFiles.ReadOnly = true;
            this.grid_remoteFiles.RowHeadersVisible = false;
            this.grid_remoteFiles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grid_remoteFiles.RowTemplate.Height = 25;
            this.grid_remoteFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_remoteFiles.Size = new System.Drawing.Size(276, 396);
            this.grid_remoteFiles.TabIndex = 5;
            // 
            // grid_remoteFiles_id
            // 
            this.grid_remoteFiles_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.grid_remoteFiles_id.DataPropertyName = "ID";
            this.grid_remoteFiles_id.HeaderText = "ID";
            this.grid_remoteFiles_id.Name = "grid_remoteFiles_id";
            this.grid_remoteFiles_id.ReadOnly = true;
            this.grid_remoteFiles_id.Width = 43;
            // 
            // grid_remoteFiles_title
            // 
            this.grid_remoteFiles_title.DataPropertyName = "Title";
            this.grid_remoteFiles_title.HeaderText = "Title";
            this.grid_remoteFiles_title.Name = "grid_remoteFiles_title";
            this.grid_remoteFiles_title.ReadOnly = true;
            // 
            // grid_remoteFiles_state
            // 
            this.grid_remoteFiles_state.DataPropertyName = "State";
            this.grid_remoteFiles_state.HeaderText = "State";
            this.grid_remoteFiles_state.Name = "grid_remoteFiles_state";
            this.grid_remoteFiles_state.ReadOnly = true;
            // 
            // rtb_logBox
            // 
            this.rtb_logBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rtb_logBox.Location = new System.Drawing.Point(555, 131);
            this.rtb_logBox.Name = "rtb_logBox";
            this.rtb_logBox.ReadOnly = true;
            this.rtb_logBox.Size = new System.Drawing.Size(298, 396);
            this.rtb_logBox.TabIndex = 6;
            this.rtb_logBox.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 533);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(255, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // lbl_total_fetched
            // 
            this.lbl_total_fetched.AutoSize = true;
            this.lbl_total_fetched.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_total_fetched.Location = new System.Drawing.Point(69, 0);
            this.lbl_total_fetched.Name = "lbl_total_fetched";
            this.lbl_total_fetched.Size = new System.Drawing.Size(198, 23);
            this.lbl_total_fetched.TabIndex = 9;
            this.lbl_total_fetched.Text = "0";
            // 
            // btn_clearLog
            // 
            this.btn_clearLog.Location = new System.Drawing.Point(697, 533);
            this.btn_clearLog.Name = "btn_clearLog";
            this.btn_clearLog.Size = new System.Drawing.Size(75, 23);
            this.btn_clearLog.TabIndex = 10;
            this.btn_clearLog.Text = "Clear";
            this.btn_clearLog.UseVisualStyleBackColor = true;
            this.btn_clearLog.Click += new System.EventHandler(this.btn_clearLog_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.5F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_total_fetched, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(273, 533);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(270, 23);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Found";
            // 
            // btn_about
            // 
            this.btn_about.Location = new System.Drawing.Point(616, 533);
            this.btn_about.Name = "btn_about";
            this.btn_about.Size = new System.Drawing.Size(75, 23);
            this.btn_about.TabIndex = 12;
            this.btn_about.Text = "About";
            this.btn_about.UseVisualStyleBackColor = true;
            this.btn_about.Click += new System.EventHandler(this.btn_about_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tb_workerCount);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btn_changeSaveLocationPath);
            this.groupBox2.Controls.Add(this.tb_saveLocationPath);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(555, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 113);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Setting";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(223, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 15);
            this.label9.TabIndex = 5;
            this.label9.Text = "BETA";
            // 
            // tb_workerCount
            // 
            this.tb_workerCount.Location = new System.Drawing.Point(61, 81);
            this.tb_workerCount.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.tb_workerCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tb_workerCount.Name = "tb_workerCount";
            this.tb_workerCount.Size = new System.Drawing.Size(150, 23);
            this.tb_workerCount.TabIndex = 4;
            this.tb_workerCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "Worker";
            // 
            // btn_changeSaveLocationPath
            // 
            this.btn_changeSaveLocationPath.Location = new System.Drawing.Point(217, 45);
            this.btn_changeSaveLocationPath.Name = "btn_changeSaveLocationPath";
            this.btn_changeSaveLocationPath.Size = new System.Drawing.Size(75, 23);
            this.btn_changeSaveLocationPath.TabIndex = 2;
            this.btn_changeSaveLocationPath.Text = "Change";
            this.btn_changeSaveLocationPath.UseVisualStyleBackColor = true;
            this.btn_changeSaveLocationPath.Click += new System.EventHandler(this.btn_changeSaveLocationPath_Click);
            // 
            // tb_saveLocationPath
            // 
            this.tb_saveLocationPath.Location = new System.Drawing.Point(6, 46);
            this.tb_saveLocationPath.Name = "tb_saveLocationPath";
            this.tb_saveLocationPath.ReadOnly = true;
            this.tb_saveLocationPath.Size = new System.Drawing.Size(205, 23);
            this.tb_saveLocationPath.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Location";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 580);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_about);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btn_clearLog);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.rtb_logBox);
            this.Controls.Add(this.grid_remoteFiles);
            this.Controls.Add(this.grid_localFiles);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "osu! Map Downloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_localFiles)).EndInit();
            this.cm_grid_local.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_remoteFiles)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_workerCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Button btn_exit;
        private GroupBox groupBox1;
        private TextBox txt_query;
        private Label label1;
        private Label label3;
        private TextBox tb_findCount;
        private Button btn_startStop;
        private Label label2;
        private Button btn_find;
        private DataGridView grid_localFiles;
        private DataGridView grid_remoteFiles;
        private RichTextBox rtb_logBox;
        private ProgressBar progressBar1;
        private Label lbl_total_fetched;
        private ComboBox cb_mode;
        private Label label5;
        private Button btn_clearLog;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label4;
        private DataGridViewTextBoxColumn grid_localFiles_id;
        private DataGridViewTextBoxColumn grid_localFiles_title;
        private DataGridViewTextBoxColumn grid_remoteFiles_id;
        private DataGridViewTextBoxColumn grid_remoteFiles_title;
        private DataGridViewTextBoxColumn grid_remoteFiles_state;
        private Button btn_generateToken;
        private Label label6;
        private TextBox tb_token;
        private Button btn_about;
        private GroupBox groupBox2;
        private Button btn_changeSaveLocationPath;
        private TextBox tb_saveLocationPath;
        private Label label7;
        private Label label9;
        private NumericUpDown tb_workerCount;
        private Label label8;
        private ContextMenuStrip cm_grid_local;
        private ToolStripMenuItem cmBtn_grid_local_refresh;
    }
}