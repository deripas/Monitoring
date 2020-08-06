using api;
using model.nvr;
using model.video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using SDK_HANDLE = System.Int32;

namespace model.camera
{
    public class CameraModel
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private NvrModel nvr;

        public int Channel { get; }

        public String Name { get; }

        public double Ratio
        {
            get
            {
                return 9D / 16D;
            }
        }

        public SDK_HANDLE LoginId
        {
            get
            {
                return nvr.LoginId;
            }
        }

        public bool Talk
        {
            get
            {
                return nvr.Talk;
            }
        }

        public int Fps
        {
            get
            {
                return 25;
            }
        }

        public CameraModel(NvrModel nvr, int channel)
        {
            this.nvr = nvr;
            this.Channel = channel;
            Name = nvr.Ip + "#" + (Channel + 1);
        }

        internal void StartTalk()
        {
            nvr.StartTalk();
        }

        internal void StopTalk()
        {
            nvr.StopTalk();
        }

        internal void Ptz(PTZ_ControlType cmd, bool stop, int speed)
        {
            var result = NetSDK.H264_DVR_PTZControl(LoginId, Channel, cmd, stop, speed);
            Log.Debug("{0}: H264_DVR_PTZControl cmd={1} value={2} {3}", this, cmd, speed, result);
        }

        public override string ToString()
        {
            return "cam(" + nvr.Ip + " #" + (Channel + 1) + ")";
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

        internal List<VideoFileModel> SearchVideoFiles(DateTime from, DateTime to, FileType type)
        {
            var result = new List<VideoFileModel>();
            List<VideoFileModel> sub;
            do
            {
                sub = SearchVideoFilesBatch(from, to, type);
                result.AddRange(sub);

                if (sub.Count > 0) from = sub.Last().EndTime;
            } while (sub.Count == 64);
            return result;
        }

        private List<VideoFileModel> SearchVideoFilesBatch(DateTime from, DateTime to, FileType fileType)
        {
            var info = new H264_DVR_FINDINFO();
            info.nChannelN0 = Channel;
            info.nFileType = (int)fileType;
            info.startTime = ToDvrTime(from);
            info.endTime = ToDvrTime(to);

            int nMaxLen = 64;
            int waitTime = 5000;
            int nNum = 0;

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(H264_DVR_FILE_DATA)) * nMaxLen);
            try
            {
                int ret = NetSDK.H264_DVR_FindFile(LoginId, ref info, ptr, nMaxLen, out nNum, waitTime);
                Log.Debug("{0}: H264_DVR_FindFile code={1}, count={2}", this, ret, nNum);
                return ToList(ptr, nNum, fileType);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        private List<VideoFileModel> ToList(IntPtr ptr, int nNum, FileType fileType)
        {
            var result = new List<VideoFileModel>();
            for (int index = 0; index < nNum; index++)
            {
                unsafe
                {
                    int* pDev = (int*)ptr.ToPointer();
                    pDev += Marshal.SizeOf(typeof(H264_DVR_FILE_DATA)) * index / 4;
                    IntPtr ptrTemp = new IntPtr(pDev);
                    var file = (H264_DVR_FILE_DATA)Marshal.PtrToStructure(ptrTemp, typeof(H264_DVR_FILE_DATA));
                    result.Add(new VideoFileModel(this, file, fileType));
                }
            }
            return result;
        }

        internal VideoTimeRangeModel SearchVideo(DateTime from, DateTime to)
        {
            var info = new H264_DVR_FINDINFO();
            info.nChannelN0 = Channel;
            info.startTime = ToDvrTime(from);
            info.endTime = ToDvrTime(to);
            return new VideoTimeRangeModel(this, info);
        }
    }
}
