using System.Configuration;
using System.Diagnostics;

namespace api
{
    public class FFmpeg
    {
        internal static void ToAvi(string h264, string avi, int rate)
        {
            var arg = string.Format("-y -f h264 -r {0} -i {1} -c:v copy {2}", rate, h264, avi);

            Process process = new Process();
            process.StartInfo.FileName = "ffmpeg.exe";
            process.StartInfo.WorkingDirectory = ConfigurationManager.AppSettings["ffmpeg.dir"] + "\\bin";
            process.StartInfo.Arguments = arg;
            process.Start();
            process.WaitForExit();
        }
    }
}
