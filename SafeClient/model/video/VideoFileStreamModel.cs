using api;
using System;
using System.Windows.Forms;
using SDK_HANDLE = System.Int32;

namespace model.video
{
    class VideoFileStreamModel
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private VideoFileModel model;
        private PictureBox canvas;
        private NetSDK.fDownLoadPosCallBack downloadCallBack;
        private NetSDK.fRealDataCallBack_V2 netdatacallbackv2;
        private int playHandleId;


        public VideoFileStreamModel(VideoFileModel model, PictureBox canvas)
        {
            this.model = model;
            this.canvas = canvas;
        }

        private int NetCallBack_V2(SDK_HANDLE lRealHandle, ref PACKET_INFO_EX pFrame, int dwUser)
        {
            return 0;
        }

        private void DownLoadPosCallback(SDK_HANDLE lPlayHandle, int lTotalSize, int lDownLoadSize, int dwUser)
        {
            if (0xfffffff == lDownLoadSize)
            {
               
            }
        }

        public void Start()
        {
            downloadCallBack = new NetSDK.fDownLoadPosCallBack(DownLoadPosCallback);
            netdatacallbackv2 = new NetSDK.fRealDataCallBack_V2(NetCallBack_V2);
            GC.KeepAlive(downloadCallBack);
            GC.KeepAlive(netdatacallbackv2);

            var data = model.Data;
            data.hWnd = canvas.Handle;
            playHandleId = NetSDK.H264_DVR_PlayBackByName_V2(model.LoginId, ref data, downloadCallBack, netdatacallbackv2, canvas.Handle);
            if (playHandleId > 0)
            {
                Log.Info("{0}: H264_DVR_PlayBackByName_V2 - OK", this);
            }
            else
            {
                Log.Info("{0}: H264_DVR_PlayBackByName_V2 -  FAIL {1}", this, NetSDK.GetLastErrorCode());
                playHandleId = 0;
                downloadCallBack = null;
                netdatacallbackv2 = null;
            }
        }

        public void Stop()
        {
            if (playHandleId > 0)
            {
                Log.Info("{0}: H264_DVR_StopPlayBack - {1}", this, NetSDK.H264_DVR_StopPlayBack(playHandleId));
                downloadCallBack = null;
                netdatacallbackv2 = null;
            }
        }

        public void Control(PlayBackAction cmd)
        {
            Control(cmd, 0);
        }

        public void Control(PlayBackAction cmd, int val)
        {
            if (playHandleId > 0)
            {
                Log.Info("{0}: H264_DVR_PlayBackControl {1}({2}) - {3}", this, cmd, val, NetSDK.H264_DVR_PlayBackControl(playHandleId, cmd, val));
            }
        }

        public override string ToString()
        {
            return model.ToString();
        }
    }
}
