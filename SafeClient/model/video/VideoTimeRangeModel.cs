using api;
using model.camera;
using System;
using SDK_HANDLE = System.Int32;

namespace model.video
{
    public class VideoTimeRangeModel : VideoPlayBackSource
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private CameraModel camera;
        private H264_DVR_FINDINFO data;

        public DateTime BeginTime { get; }
        public DateTime EndTime { get; }


        public VideoTimeRangeModel(CameraModel camera, H264_DVR_FINDINFO data)
        {
            this.camera = camera;
            this.data = data;

            BeginTime = ToDateTime(data.startTime);
            EndTime = ToDateTime(data.endTime);
        }

        private DateTime ToDateTime(H264_DVR_TIME t)
        {
            return new DateTime(t.dwYear, t.dwMonth, t.dwDay, t.dwHour, t.dwMinute, t.dwSecond);
        }

        public SDK_HANDLE Play(IntPtr canvas)
        {
            data.hWnd = canvas;
            var playHandleId = NetSDK.H264_DVR_PlayBackByTimeEx(camera.LoginId, ref data, null, canvas, null, canvas);
            if (playHandleId >= 0)
                Log.Info("{0}: H264_DVR_PlayBackByTime - OK", this);
            else
                Log.Info("{0}: H264_DVR_PlayBackByTime -  FAIL {1}", this, NetSDK.GetLastErrorCode());

            return playHandleId;
        }

        public override string ToString()
        {
            return string.Format("[{0}-{1}]", time(BeginTime), time(EndTime));
        }

        private string time(DateTime dt)
        {
            return String.Format("{0:HH:mm:ss}", dt);
        }
    }
}
