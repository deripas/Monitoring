using api;
using model.camera;
using System;
using SDK_HANDLE = System.Int32;

namespace model.video
{
    public class VideoFileModel : VideoPlayBackSource
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private H264_DVR_FILE_DATA data;
        private FileType fileType;

        public CameraModel camera { get; }
        public DateTime BeginTime { get; }
        public DateTime EndTime { get; }

        public VideoFileModel(CameraModel camera, H264_DVR_FILE_DATA data, FileType fileType)
        {
            this.camera = camera;
            this.data = data;
            this.fileType = fileType;

            BeginTime = ToDateTime(data.stBeginTime);
            EndTime = ToDateTime(data.stEndTime);
        }

        private DateTime ToDateTime(SDK_SYSTEM_TIME t)
        {
            return new DateTime(t.year, t.month, t.day, t.hour, t.minute, t.second);
        }

        public SDK_HANDLE Play(IntPtr canvas)
        {
            data.hWnd = canvas;
            var playHandleId = NetSDK.H264_DVR_PlayBackByName(camera.LoginId, ref data, null, null, canvas);
            if (playHandleId >= 0)
                Log.Info("{0}: H264_DVR_PlayBackByName - OK", this);
            else
                Log.Info("{0}: H264_DVR_PlayBackByName -  FAIL {1}", this, NetSDK.GetLastErrorCode());

            return playHandleId;
        }

        internal SDK_HANDLE Export(string file, DateTime from, DateTime to)
        {
            var info = new H264_DVR_FINDINFO();
            info.nChannelN0 = camera.Channel;
            info.startTime = ToDvrTime(from);
            info.endTime = ToDvrTime(to);

            var downloadHandleId = NetSDK.H264_DVR_GetFileByTime(camera.LoginId, ref info, file, true, null, 0, null);
            if (downloadHandleId >= 0)
                Log.Info("{0}: H264_DVR_GetFileByTime - OK", this);
            else
                Log.Info("{0}: H264_DVR_GetFileByTime -  FAIL {1}", this, NetSDK.GetLastErrorCode());

            return downloadHandleId;
        }

        private H264_DVR_TIME ToDvrTime(DateTime t)
        {
            H264_DVR_TIME time = new H264_DVR_TIME();
            time.dwYear = t.Year;
            time.dwMonth = t.Month;
            time.dwDay = t.Day;
            time.dwHour = t.Hour;
            time.dwMinute = t.Minute;
            time.dwSecond = t.Second;
            return time;
        }

        public override string ToString()
        {
            return string.Format("[{0:HH:mm:ss} - {1:HH:mm:ss}] {2}", BeginTime, EndTime, type(fileType));
        }

        private string type(FileType type)
        {
            switch (type)
            {
                case FileType.SDK_RECORD_ALARM: return "A";
                case FileType.SDK_RECORD_DETECT: return "D";
                case FileType.SDK_RECORD_REGULAR: return "R";
                case FileType.SDK_RECORD_MANUAL: return "M";
                default: return "";
            }
        }
    }
}
