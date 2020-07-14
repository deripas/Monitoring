using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using api;
using api.dto;
using model.nvr;
using SDK_HANDLE = System.Int32;

namespace service
{
    public class NvrService
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();
        private static readonly int ConnectionTimeMs = Int32.Parse(ConfigurationManager.AppSettings["nvr.connect.time.ms"]);

        private Dictionary<IPEndPoint, NvrController> NvrMap;
        private NetSDK.fDisConnect disconnectCallback;

        public NvrService()
        {
            SetDllDirectory(ConfigurationManager.AppSettings["cms.dir"]);
            disconnectCallback = new NetSDK.fDisConnect(FDisconnectCallback);
            GC.KeepAlive(disconnectCallback);

            NvrMap = new Dictionary<IPEndPoint, NvrController>();

            Log.Info("H264_DVR_Init {0}", NetSDK.H264_DVR_Init(disconnectCallback, IntPtr.Zero));
            Log.Info("H264_DVR_SetConnectTime {0}", NetSDK.H264_DVR_SetConnectTime(ConnectionTimeMs, 1));
        }

        internal void Dispose()
        {
            Log.Info("H264_DVR_Cleanup {0}", NetSDK.H264_DVR_Cleanup());
        }
        
        private void FDisconnectCallback(SDK_HANDLE LoginID, string DVRIP, int DVRPort, IntPtr dwUser)
        {
            Log.Info("Disconnect callback {0} {1} {2}", LoginID, DVRIP, dwUser);
            var ip = IPAddress.Parse(DVRIP);
            var address = new IPEndPoint(ip, DVRPort);
            var nvr = NvrMap[address];
            nvr?.Disconnect();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        internal NvrController Login(NvrInfo nvr)
        {
            var key = nvr.GetAddress();
            if (NvrMap.ContainsKey(key))
            {
                return NvrMap[key];
            }
            else
            {
                var nvrController = new NvrController(nvr);
                NvrMap.Add(key, nvrController);
                return nvrController;
            }
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool SetDllDirectory(string lpPathName);
    }
}