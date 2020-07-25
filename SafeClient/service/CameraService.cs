using api;
using api.dto;
using model.camera;
using model.nvr;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using SDK_HANDLE = System.Int32;

namespace service
{
    public class CameraService
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();
        private static readonly int ConnectionTimeMs = Int32.Parse(ConfigurationManager.AppSettings["nvr.connect.time.ms"]);

        private Timer timer;
        private NetSDK.fDisConnect disconnectCallback;
        private Dictionary<long, CameraController> _cameraMap;
        private Dictionary<IPEndPoint, NvrController> _nvrMap;

        public List<CameraController> CameraList { get; }

        public CameraService(List<CameraInfo> list)
        {
            _nvrMap = new Dictionary<IPEndPoint, NvrController>();
            _cameraMap = new Dictionary<long, CameraController>();
            CameraList = new List<CameraController>();

            SetDllDirectory(ConfigurationManager.AppSettings["sdk.dir"]);
            disconnectCallback = new NetSDK.fDisConnect(FDisconnectCallback);
            GC.KeepAlive(disconnectCallback);

            Log.Info("H264_DVR_Init {0}", NetSDK.H264_DVR_Init(disconnectCallback, IntPtr.Zero));
            Log.Info("H264_DVR_SetConnectTime {0}", NetSDK.H264_DVR_SetConnectTime(ConnectionTimeMs, 1));

            foreach (CameraInfo camera in list)
            {
                var nvr = Nvr(camera.NvrInfo);
                var cam = nvr.Camera(camera.Chanel);
                CameraList.Add(cam);
                _cameraMap.Add(camera.Id, cam);
            }

            timer = new Timer(TimerCallback, this, 200, 200);
        }

        private void FDisconnectCallback(SDK_HANDLE LoginID, string DVRIP, int DVRPort, IntPtr dwUser)
        {
            Log.Info("Disconnect callback {0} {1} {2}", LoginID, DVRIP, dwUser);
            var ip = IPAddress.Parse(DVRIP);
            var address = new IPEndPoint(ip, DVRPort);
            var nvr = _nvrMap[address];
            nvr?.Disconnect();
        }

        private void TimerCallback(object state)
        {
            foreach (var nvr in _nvrMap.Values)
                nvr.Check();
        }

        internal void StopTalk()
        {
            foreach (var nvr in _nvrMap.Values)
                nvr.StopTalk();
        }

        internal void CloseSound()
        {
            foreach (var nvr in _nvrMap.Values)
                nvr.CloseSound();
        }

        internal NvrController Nvr(NvrInfo nvr)
        {
            var key = nvr.GetAddress();
            if (_nvrMap.ContainsKey(key))
            {
                return _nvrMap[key];
            }
            else
            {
                var nvrController = new NvrController(nvr);
                _nvrMap.Add(key, nvrController);
                return nvrController;
            }
        }

        internal void Dispose()
        {
            timer.Dispose();
            foreach (var nvr in _nvrMap.Values)
                nvr.Disconnect();

            Log.Info("H264_DVR_Cleanup {0}", NetSDK.H264_DVR_Cleanup());
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool SetDllDirectory(string lpPathName);
    }
}
