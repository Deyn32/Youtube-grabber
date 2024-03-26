namespace YouTube_Downloader
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            rtbLinks = new RichTextBox();
            panel1 = new Panel();
            btnStart = new Button();
            lbDownloadDirectory = new Label();
            label2 = new Label();
            btnOpenDownloadFolder = new Button();
            pbDownload = new ProgressBar();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 24);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 0;
            label1.Text = "Список ссылок";
            // 
            // rtbLinks
            // 
            rtbLinks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbLinks.Location = new Point(3, 42);
            rtbLinks.Name = "rtbLinks";
            rtbLinks.Size = new Size(413, 396);
            rtbLinks.TabIndex = 1;
            rtbLinks.Text = "";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnStart);
            panel1.Controls.Add(lbDownloadDirectory);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnOpenDownloadFolder);
            panel1.Location = new Point(422, 42);
            panel1.Name = "panel1";
            panel1.Size = new Size(249, 232);
            panel1.TabIndex = 2;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(58, 138);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(147, 57);
            btnStart.TabIndex = 3;
            btnStart.Text = "Начать загрузку";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // lbDownloadDirectory
            // 
            lbDownloadDirectory.AutoSize = true;
            lbDownloadDirectory.Location = new Point(30, 45);
            lbDownloadDirectory.Name = "lbDownloadDirectory";
            lbDownloadDirectory.Size = new Size(0, 15);
            lbDownloadDirectory.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 15);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 1;
            label2.Text = "Каталог загрузки";
            // 
            // btnOpenDownloadFolder
            // 
            btnOpenDownloadFolder.Location = new Point(47, 78);
            btnOpenDownloadFolder.Name = "btnOpenDownloadFolder";
            btnOpenDownloadFolder.Size = new Size(167, 23);
            btnOpenDownloadFolder.TabIndex = 0;
            btnOpenDownloadFolder.Text = "Выбрать каталог загрузки";
            btnOpenDownloadFolder.UseVisualStyleBackColor = true;
            btnOpenDownloadFolder.Click += btnOpenDownloadFolder_Click;
            // 
            // pbDownload
            // 
            pbDownload.Location = new Point(422, 378);
            pbDownload.Name = "pbDownload";
            pbDownload.Size = new Size(249, 23);
            pbDownload.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(687, 450);
            Controls.Add(pbDownload);
            Controls.Add(panel1);
            Controls.Add(rtbLinks);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Скачай с YouTube";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RichTextBox rtbLinks;
        private Panel panel1;
        private Button btnOpenDownloadFolder;
        private Button btnStart;
        private Label lbDownloadDirectory;
        private Label label2;
        private ProgressBar pbDownload;
    }
}
