using DotNetTools.SharpGrabber.Grabbed;
using DotNetTools.SharpGrabber;
using DotNetTools.SharpGrabber.Converter;

namespace YouTube_Downloader.Services
{
    internal class YouTubeDownloadServiceImpl : IYouTubeDownloadService
    {
        private static readonly HashSet<string> TempFiles = new HashSet<string>();

        public async void Download(string url, string pathDownload)
        {
            var grabber = GrabberBuilder.New().UseDefaultServices().AddYouTube().Build();
            var result = await grabber.GrabAsync(new Uri(url));

            var audioStream = ChooseMonoMedia(result, MediaChannels.Audio);
            MessageBox.Show("Получили аудио");
            var videoStream = ChooseMonoMedia(result, MediaChannels.Video);
            MessageBox.Show("Получили видео");
            
            if (audioStream == null)
                throw new InvalidOperationException("No audio stream detected.");
            if (videoStream == null)
                throw new InvalidOperationException("No video stream detected.");

            try
            {
                var audioPath = await DownloadMedia(audioStream, result);
                MessageBox.Show("Аудио загружено!");
                var videoPath = await DownloadMedia(videoStream, result);
                MessageBox.Show("Загружено видео!");
                GenerateOutputFile(audioPath, videoPath, videoStream, pathDownload);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!" + ex.Message);
            }
            finally
            {
                foreach (var tempFile in TempFiles)
                {
                    try
                    {
                        File.Delete(tempFile);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось удалить мусорный файл " + tempFile + "\n"
                            + ex.Message);
                    }
                }
            }
        }

        private static GrabbedMedia ChooseMonoMedia(GrabResult result, MediaChannels channel)
        {
            var resources = result.Resources<GrabbedMedia>()
                .Where(m => m.Channels == channel)
                .ToList();
            
            return resources[0];
        }

        private static async Task<string> DownloadMedia(GrabbedMedia media, IGrabResult grabResult)
        {
            string? path;

            using(HttpClient Client = new HttpClient())
            {
                Client.Timeout = TimeSpan.FromSeconds(1200000);
                Client.MaxResponseContentBufferSize = int.MaxValue;
                using var response = await Client.GetAsync(media.ResourceUri, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                using var downloadStream = await response.Content.ReadAsStreamAsync();
                using var resourceStream = await grabResult.WrapStreamAsync(downloadStream);

                path = Path.GetRandomFileName();

                using var fileStream = new FileStream(path, FileMode.Create);
                TempFiles.Add(path);
                await resourceStream.CopyToAsync(fileStream);
            }
            
            return path;
        }

        private static void GenerateOutputFile(string audioPath, string videoPath, GrabbedMedia videoStream, string pathDownload)
        {
            var merger = new MediaMerger(pathDownload);
            merger.AddStreamSource(audioPath, MediaStreamType.Audio);
            merger.AddStreamSource(videoPath, MediaStreamType.Video);
            merger.OutputMimeType = videoStream.Format.Mime;
            merger.OutputShortName = videoStream.Format.Extension;
            merger.Build();
        }
    }
}
