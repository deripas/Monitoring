using api;
using model.nvr;
using model.video;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using SDK_HANDLE = System.Int32;

namespace model.camera
{
    public class CameraModel
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private NvrModel nvr;

        public int Channel { get; }

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

        public CameraModel(NvrModel nvr, int channel)
        {
            this.nvr = nvr;
            this.Channel = channel;
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
            NetSDK.H264_DVR_PTZControl(LoginId, Channel, cmd, stop, speed);
            Log.Debug("{0}: H264_DVR_PTZControl cmd={1}", this, cmd);
        }

        public override string ToString()
        {
            return "cam(" + nvr.Ip + " #" + (Channel + 1) + ")";
        }

        internal List<VideoFileModel> SearchVideo(H264_DVR_TIME startTime, H264_DVR_TIME endTime, FileType fileType)
        {
            var info = new H264_DVR_FINDINFO();
            info.nChannelN0 = Channel;
            info.nFileType = (int)fileType;
            info.startTime = startTime;
            info.endTime = endTime;

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
    }
}
