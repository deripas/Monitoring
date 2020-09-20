using api;
using model.camera;
using NetSDKCS;
using System;
using SDK_HANDLE = System.Int32;

namespace model.video
{
    public class VideoTimeRangeModel : VideoPlayBackSource
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private CameraModel camera;

        public DateTime BeginTime { get; }
        public DateTime EndTime { get; }
        public string Name => camera.Name;

        public VideoTimeRangeModel(CameraModel camera, DateTime from, DateTime to)
        {
            this.camera = camera;

            BeginTime = NET_TIME.FromDateTime(from).ToDateTime();
            EndTime = NET_TIME.FromDateTime(to).ToDateTime();
        }

        public IntPtr Play(IntPtr canvas, DateTime startTime, DateTime endTime)
        {
            NET_OUT_PLAY_BACK_BY_TIME_INFO stuOut = new NET_OUT_PLAY_BACK_BY_TIME_INFO();
            
            NET_IN_PLAY_BACK_BY_TIME_INFO stuInfo = new NET_IN_PLAY_BACK_BY_TIME_INFO();
            stuInfo.stStartTime = NET_TIME.FromDateTime(startTime);
            stuInfo.stStopTime = NET_TIME.FromDateTime(endTime);
            stuInfo.hWnd = canvas;
            stuInfo.cbDownLoadPos = null;
            stuInfo.dwPosUser = IntPtr.Zero;
            stuInfo.fDownLoadDataCallBack = null;
            stuInfo.dwDataUser = IntPtr.Zero;
            stuInfo.nPlayDirection = 0;
            stuInfo.nWaittime = 5000;

            var playHandleId = NETClient.PlayBackByTime(camera.LoginId, camera.Channel, stuInfo, ref stuOut);
            if (playHandleId != IntPtr.Zero)
                Log.Info("{0}: NETClient.PlayBackByTime - OK", this);
            else
                Log.Info("{0}: NETClient.PlayBackByTime -  FAIL {1}", this, NETClient.GetLastError());

            return playHandleId;
        }

        public IntPtr Export(string file, DateTime from, DateTime to, fTimeDownLoadPosCallBack m_DownloadPosCallBack)
        {
            var downloadHandleId = NETClient.DownloadByTime(camera.LoginId, camera.Channel, EM_QUERY_RECORD_TYPE.ALL, from, to, file, m_DownloadPosCallBack, IntPtr.Zero, null, IntPtr.Zero, IntPtr.Zero);
            if (downloadHandleId != IntPtr.Zero)
                Log.Info("{0}: NETClient.DownloadByRecordFile - OK", this);
            else
                Log.Info("{0}: NETClient.DownloadByRecordFile -  FAIL {1}", this, NETClient.GetLastError());

            return downloadHandleId;
        }

        public override string ToString()
        {
            return $"[{time(BeginTime)}-{time(EndTime)}]";
        }

        private string time(DateTime dt)
        {
            return $"{dt:HH:mm:ss}";
        }
    }
}
