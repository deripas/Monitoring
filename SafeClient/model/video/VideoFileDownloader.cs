using api;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using SDK_HANDLE = System.Int32;

namespace model.video
{
    public class VideoFileDownloader
    {

        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private SDK_HANDLE downloadHandleId;
        private string tmp;

        public VideoFileDownloader()
        {
            tmp = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tmp);
            Log.Info("{0}: temp directory: {1}", this, tmp);
        }

        public int Start(VideoFileModel video, DateTime from, DateTime to)
        {
            ClearDirectory();
            var files = video.camera.SearchVideoFiles(from, to, FileType.SDK_RECORD_ALL);
            var totalMilliseconds = files
                .Select(v => v.EndTime - v.BeginTime)
                .Select(t => t.TotalMilliseconds)
                .Sum();
            var subMilliseconds = (to - from).TotalMilliseconds;
            var percent = Convert.ToInt32(100 * subMilliseconds / totalMilliseconds);
            Log.Info("{0}: download video percent {1}", this, percent);

            downloadHandleId = video.Export(tmp, from, to);
            if (downloadHandleId < 0)
            {
                Stop();
                return -1;
            }

            return percent;
        }

        private void ClearDirectory()
        {
            var files = Directory.GetFiles(tmp, "*.h264");
            if (files != null)
                foreach (var file in files)
                    File.Delete(file);
        }

        public void Stop()
        {
            if (downloadHandleId >= 0)
                Log.Info("{0}: H264_DVR_StopGetFile - {1}", this, NetSDK.H264_DVR_StopGetFile(downloadHandleId));
            
            downloadHandleId = -1;
        }

        public int GetPos()
        {
            if (downloadHandleId < 0) return 0;
            return NetSDK.H264_DVR_GetDownloadPos(downloadHandleId);
        }

        public void Dispose()
        {
            Directory.Delete(tmp, true);
        }

        public override string ToString()
        {
            return "downloader";
        }

        public bool MoveTo(string fileName)
        {
            Log.Info("{0}: move video to {1}", this, fileName);
            var files = Directory.GetFiles(tmp, "*.h264");
            if (files == null || files.Length != 1)
                return false;

            if (File.Exists(fileName))
                File.Delete(fileName);

            if (fileName.EndsWith(".h264", true, CultureInfo.CurrentCulture))
            {
                Log.Info("{0}: native move file {1} to {2}", this, files[0], fileName);
                File.Move(files[0], fileName);
                return true;
            }

            if (fileName.EndsWith(".avi", true, CultureInfo.CurrentCulture))
            {
                Log.Info("{0}: ffmpeg code {1} to {2}", this, files[0], fileName);
                FFmpeg.ToAvi(files[0], fileName);
                return true;
            }
            return false;
        }
    }
}
