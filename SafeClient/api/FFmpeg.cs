using System.Configuration;
using System.Diagnostics;

namespace api
{
    public class FFmpeg
    {
        internal static void ToAvi(string h264, string avi, int rate)
        {
            var arg = string.Format("-y -f h264 -i {0} -c:v copy -r {1} {2}", h264, rate, avi);

            Process process = new Process();
            process.StartInfo.FileName = "ffmpeg.exe";
            process.StartInfo.WorkingDirectory = ConfigurationManager.AppSettings["ffmpeg.dir"] + "\\bin";
            process.StartInfo.Arguments = arg;
            process.Start();
            process.WaitForExit();
        }
    }
}
