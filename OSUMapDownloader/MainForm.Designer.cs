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
            this.button1 = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_findCount = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_find = new System.Windows.Forms.Button();
            this.txt_query = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grid_localFiles = new System.Windows.Forms.DataGridView();
            this.grid_local_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_local_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_remoteFiles = new System.Windows.Forms.DataGridView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            this.lbl_total_fetched = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.cb_mode = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_localFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_remoteFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(189, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Setting";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(270, 393);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 36);
            this.btn_exit.TabIndex = 1;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_mode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_findCount);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_find);
            this.groupBox1.Controls.Add(this.txt_query);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 153);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "map";
            // 
            // tb_findCount
            // 
            this.tb_findCount.Location = new System.Drawing.Point(87, 62);
            this.tb_findCount.Name = "tb_findCount";
            this.tb_findCount.Size = new System.Drawing.Size(100, 23);
            this.tb_findCount.TabIndex = 5;
            this.tb_findCount.Text = "100";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(416, 112);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Start";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Stop after:";
            // 
            // btn_find
            // 
            this.btn_find.Location = new System.Drawing.Point(429, 22);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(75, 23);
            this.btn_find.TabIndex = 2;
            this.btn_find.Text = "Find";
            this.btn_find.UseVisualStyleBackColor = true;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // txt_query
            // 
            this.txt_query.Location = new System.Drawing.Point(87, 22);
            this.txt_query.Name = "txt_query";
            this.txt_query.Size = new System.Drawing.Size(336, 23);
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
            this.grid_localFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_localFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_localFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grid_local_id,
            this.grid_local_name});
            this.grid_localFiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid_localFiles.Location = new System.Drawing.Point(57, 171);
            this.grid_localFiles.MultiSelect = false;
            this.grid_localFiles.Name = "grid_localFiles";
            this.grid_localFiles.ReadOnly = true;
            this.grid_localFiles.RowHeadersVisible = false;
            this.grid_localFiles.RowTemplate.Height = 25;
            this.grid_localFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_localFiles.Size = new System.Drawing.Size(257, 150);
            this.grid_localFiles.TabIndex = 4;
            // 
            // grid_local_id
            // 
            this.grid_local_id.HeaderText = "ID";
            this.grid_local_id.Name = "grid_local_id";
            this.grid_local_id.ReadOnly = true;
            // 
            // grid_local_name
            // 
            this.grid_local_name.HeaderText = "Name";
            this.grid_local_name.Name = "grid_local_name";
            this.grid_local_name.ReadOnly = true;
            // 
            // grid_remoteFiles
            // 
            this.grid_remoteFiles.AllowUserToAddRows = false;
            this.grid_remoteFiles.AllowUserToDeleteRows = false;
            this.grid_remoteFiles.AllowUserToResizeRows = false;
            this.grid_remoteFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_remoteFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_remoteFiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid_remoteFiles.Location = new System.Drawing.Point(365, 171);
            this.grid_remoteFiles.MultiSelect = false;
            this.grid_remoteFiles.Name = "grid_remoteFiles";
            this.grid_remoteFiles.ReadOnly = true;
            this.grid_remoteFiles.RowHeadersVisible = false;
            this.grid_remoteFiles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grid_remoteFiles.RowTemplate.Height = 25;
            this.grid_remoteFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_remoteFiles.Size = new System.Drawing.Size(305, 356);
            this.grid_remoteFiles.TabIndex = 5;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(676, 77);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(399, 259);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 339);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(268, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(547, 533);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbl_total_fetched
            // 
            this.lbl_total_fetched.AutoSize = true;
            this.lbl_total_fetched.Location = new System.Drawing.Point(389, 538);
            this.lbl_total_fetched.Name = "lbl_total_fetched";
            this.lbl_total_fetched.Size = new System.Drawing.Size(13, 15);
            this.lbl_total_fetched.TabIndex = 9;
            this.lbl_total_fetched.Text = "0";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(247, 479);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(83, 19);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(474, 575);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cb_mode
            // 
            this.cb_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_mode.FormattingEnabled = true;
            this.cb_mode.Location = new System.Drawing.Point(87, 91);
            this.cb_mode.Name = "cb_mode";
            this.cb_mode.Size = new System.Drawing.Size(121, 23);
            this.cb_mode.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 633);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lbl_total_fetched);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.grid_remoteFiles);
            this.Controls.Add(this.grid_localFiles);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OSU! Map Downloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_localFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_remoteFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private Button btn_exit;
        private GroupBox groupBox1;
        private TextBox txt_query;
        private Label label1;
        private Label label3;
        private TextBox tb_findCount;
        private Button button4;
        private Label label2;
        private Button btn_find;
        private DataGridView grid_localFiles;
        private DataGridView grid_remoteFiles;
        private RichTextBox richTextBox1;
        private DataGridViewTextBoxColumn grid_local_id;
        private DataGridViewTextBoxColumn grid_local_name;
        private ProgressBar progressBar1;
        private Button button2;
        private Label lbl_total_fetched;
        private CheckBox checkBox1;
        private Button button3;
        private ComboBox cb_mode;
    }
}