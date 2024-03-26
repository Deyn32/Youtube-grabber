using YouTube_Downloader.Services;

namespace YouTube_Downloader
{
    public partial class Form1 : Form
    {

        private readonly IYouTubeDownloadService service = new YouTubeDownloadServiceImpl();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenDownloadFolder_Click(object sender, EventArgs e)
        {
            using(var fbd = new FolderBrowserDialog())
            {
                fbd.ShowDialog();

                if(!string.IsNullOrEmpty(fbd.SelectedPath) )
                {
                    lbDownloadDirectory.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string[] str = rtbLinks.Text.Split("\n");
            /*pbDownload.Minimum = 1;
            pbDownload.Maximum = str.Length;
            pbDownload.Value = 1;
            pbDownload.Step = 1;*/

            Task.Run(() =>
            {
                foreach(var item in str) 
                {
                    service.Download(item, lbDownloadDirectory.Text);
                }
                /*Parallel.ForEach(str, url =>
                {
                    service.Download(url, lbDownloadDirectory.Text);
                    Invoke(new Action(() => pbDownload.PerformStep()));
                });*/
            });

            //https://www.youtube.com/watch?v=mz8EX7Lncu8&t=4s
        }
    }
}
