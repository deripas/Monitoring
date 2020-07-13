using System;
using System.Net;
using api;
using SDK_HANDLE = System.Int32;

namespace service
{
    public class NvrService
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();
        private readonly NetSDK.fDisConnect disconnectCallback;
        
        internal void Init()
        {
            Log.Info("H264_DVR_Init {0}",   NetSDK.H264_DVR_Init(disconnectCallback, IntPtr.Zero));
        }
        internal void Dispose()
        {
            Log.Info("H264_DVR_Cleanup {0}",   NetSDK.H264_DVR_Cleanup());
        }
        
        private void FDisconnectCallback(SDK_HANDLE LoginID, string DVRIP, int DVRPort, IntPtr dwUser)
        {
            var ip = IPAddress.Parse(DVRIP);
            var address = new IPEndPoint(ip, DVRPort);
            Log.Info("Disconnect callback {0} {1} {2}", LoginID, address, dwUser);
        }
    }
}