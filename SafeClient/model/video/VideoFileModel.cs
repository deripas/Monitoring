using api;
using model.camera;
using System;
using SDK_HANDLE = System.Int32;

namespace model.video
{
    public class VideoFileModel
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private CameraModel camera;
        private H264_DVR_FILE_DATA data;
        private FileType fileType;

        public DateTime BeginTime { get; }
        public DateTime EndTime { get; }

        public SDK_HANDLE LoginId
        {
            get
            {
                return camera.LoginId;
            }
        }

        public H264_DVR_FILE_DATA Data
        {
            get
            {
                return data;
            }
        }

        public VideoFileModel(CameraModel camera, H264_DVR_FILE_DATA data, FileType fileType)
        {
            this.camera = camera;
            this.data = data;
            this.fileType = fileType;
            
            BeginTime = ToDateTime(data.stBeginTime);
            EndTime = ToDateTime(data.stEndTime);            
        }

        public override string ToString()
        {
            return string.Format("[{0}-{1}] {2}", time(BeginTime), time(EndTime), type(fileType));
        }

        private string time(DateTime dt)
        {
            return String.Format("{0:HH:mm:ss}", dt);
        }

        private string type(FileType type)
        {
            switch (type)
            {
                case FileType.SDK_RECORD_ALARM: return "A";
                case FileType.SDK_RECORD_DETECT: return "D";
                case FileType.SDK_RECORD_REGULAR: return "R";
                case FileType.SDK_RECORD_MANUAL: return "M";
                default: return "?";
            }
        }

        public H264_DVR_TIME GetEndDvrTime()
        {
            return ToDvrTime(data.stEndTime);
        }

        private H264_DVR_TIME ToDvrTime(SDK_SYSTEM_TIME t)
        {
            H264_DVR_TIME time = new H264_DVR_TIME();
            time.dwYear = t.year;
            time.dwMonth = t.month;
            time.dwDay = t.day;
            time.dwHour = t.hour;
            time.dwMinute = t.minute;
            time.dwSecond = t.second;
            return time;
        }

        private DateTime ToDateTime(SDK_SYSTEM_TIME t)
        {
            return new DateTime(t.year, t.month, t.day, t.hour, t.minute, t.second);
        }
    }
}
