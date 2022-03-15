namespace OSUMapDownloader
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txt_labelVersion = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_labelCopyright = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Baskerville Old Face", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "osu! Map Downloader";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txt_labelVersion
            // 
            this.txt_labelVersion.AutoSize = true;
            this.txt_labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_labelVersion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_labelVersion.Location = new System.Drawing.Point(3, 36);
            this.txt_labelVersion.Name = "txt_labelVersion";
            this.txt_labelVersion.Size = new System.Drawing.Size(360, 17);
            this.txt_labelVersion.TabIndex = 1;
            this.txt_labelVersion.Text = "Version 1.0.0";
            this.txt_labelVersion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt_labelVersion, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_labelCopyright, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.92453F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.07547F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(366, 143);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // txt_labelCopyright
            // 
            this.txt_labelCopyright.AutoSize = true;
            this.txt_labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_labelCopyright.Location = new System.Drawing.Point(3, 53);
            this.txt_labelCopyright.Name = "txt_labelCopyright";
            this.txt_labelCopyright.Size = new System.Drawing.Size(360, 63);
            this.txt_labelCopyright.TabIndex = 2;
            this.txt_labelCopyright.Text = "Created with ♥ by incikweskerzz\r\nfor\r\nOsuLovers (read Pehimos)";
            this.txt_labelCopyright.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(360, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Copyright © 2022 Lepak.xyz";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 163);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "osu! Map Downloader by IncikWeskerzzz";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private Label txt_labelVersion;
        private TableLayoutPanel tableLayoutPanel1;
        private Label txt_labelCopyright;
        private Label label2;
    }
}
