using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTube_Downloader.Services
{
    internal interface IYouTubeDownloadService
    {
        public void Download(string url, string pathDownload);
    }
}
