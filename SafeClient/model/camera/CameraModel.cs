using api;
using api.dto;
using model.nvr;
using model.video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.ApplicationServices;
using NetSDKCS;
using SDK_HANDLE = System.Int32;

namespace model.camera
{
    public class CameraModel
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private NvrModel nvr;
        private double ratio = 9D / 16D;

        public int Channel { get; }

        public String Name { get; }
        public String Stand { get; }

        public double Ratio
        {
            get
            {
                return ratio;
            }
            set
            {
                ratio = value;
            }
        }

        public IntPtr LoginId
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

        public CameraModel(NvrModel nvr, CameraInfo info)
        {
            this.nvr = nvr;
            this.Channel = info.channel - 1;
            Name = info.name;
            Stand = info.stand;
        }

        internal void StartTalk()
        {
            nvr.StartTalk();
        }

        internal void StopTalk()
        {
            nvr.StopTalk();
        }

        internal void Logout()
        {
            nvr.Logout();
        }

        internal void Ptz(EM_EXTPTZ_ControlType cmd, bool stop, int speed)
        {
            var result = NETClient.PTZControl(LoginId, Channel, cmd, 0, speed, 0, stop,  IntPtr.Zero);
            Log.Debug("{0}: NETClient.PTZControl cmd={1} value={2} {3}", this, cmd, speed, result);
        }

        public override string ToString()
        {
            return "cam(" + nvr.Ip + " #" + (Channel + 1) + ")";
        }

        internal List<VideoFileModel> SearchVideoFiles(DateTime from, DateTime to, EM_QUERY_RECORD_TYPE type)
        {
            return SearchVideoFilesBatch(from, to, type);
        }

        private List<VideoFileModel> SearchVideoFilesBatch(DateTime from, DateTime to, EM_QUERY_RECORD_TYPE fileType)
        {
            int fileCount = 0;
            NET_RECORDFILE_INFO[] recordFileArray = new NET_RECORDFILE_INFO[5000];
            bool ret = QueryFile(from, to, fileType, ref recordFileArray, ref fileCount);
            Log.Debug("{0}: NETClient.QueryRecordFile code={1}, count={2}", this, ret, fileCount);
            return ToList(recordFileArray, fileCount);
        }

        private bool QueryFile(DateTime startTime, DateTime endTime, EM_QUERY_RECORD_TYPE nRecordFileType, ref NET_RECORDFILE_INFO[] infos ,ref int fileCount)
        {
            int waitTime = 5000;
            //set stream type 设置码流类型
            EM_STREAM_TYPE streamType = EM_STREAM_TYPE.MAIN;
            IntPtr pStream = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(int)));
            Marshal.StructureToPtr((int)streamType, pStream, true);
            NETClient.SetDeviceMode(LoginId, EM_USEDEV_MODE.RECORD_STREAM_TYPE, pStream);
            //query record file 查询录像文件
            return NETClient.QueryRecordFile(LoginId, Channel, nRecordFileType, startTime, endTime, null, ref infos, ref fileCount, waitTime, false);
        }


        private List<VideoFileModel> ToList(NET_RECORDFILE_INFO[] recordFileArray, int fileCount)
        {
            var result = new List<VideoFileModel>();
            for (int index = 0; index < fileCount; index++)
            {
                result.Add(new VideoFileModel(this, recordFileArray[index]));
            }
            return result;
        }

        internal VideoTimeRangeModel SearchVideo(DateTime from, DateTime to)
        {
            return new VideoTimeRangeModel(this, from, to);
        }
    }
}
