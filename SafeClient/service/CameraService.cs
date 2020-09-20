using api;
using api.dto;
using model.camera;
using model.nvr;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using NetSDKCS;
using SDK_HANDLE = System.Int32;

namespace service
{
    public class CameraService
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();
        private static readonly int ConnectionTimeMs = Int32.Parse(ConfigurationManager.AppSettings["nvr.connect.time.ms"]);

        private static fDisConnectCallBack m_DisConnectCallBack; //Disconnect the callback
        private static fHaveReConnectCallBack m_ReConnectCallBack; //Disconnect the callback
        
        private Dictionary<long, CameraController> _cameraMap;
        private Dictionary<IPEndPoint, NvrController> _nvrMap;
        private Dictionary<int, NvrController> _nvrMapById;

        public List<CameraController> CameraList { get; }

        public CameraController this[int id] => _cameraMap[id];

        public CameraService(IServerApi serverApi)
        {
            _nvrMap = new Dictionary<IPEndPoint, NvrController>();
            _nvrMapById = new Dictionary<int, NvrController>();
            _cameraMap = new Dictionary<long, CameraController>();
            CameraList = new List<CameraController>();

            SetDllDirectory(ConfigurationManager.AppSettings["netsdk.dir"]);
            
            m_DisConnectCallBack = DisConnectCallBack;
            m_ReConnectCallBack = ReConnectCallBack;

            NET_PARAM param = new NET_PARAM()
            {
                nConnectTime = ConnectionTimeMs,
                nsubDisconnetTime = 10_000
            };
            
            Log.Info("NETClient.Init {0}", NETClient.Init(m_DisConnectCallBack, IntPtr.Zero, null));
            //Set auto reconnecting after disconnection
            NETClient.SetAutoReconnect(m_ReConnectCallBack, IntPtr.Zero);
            //Set network parameters
            NETClient.SetNetworkParam(param);

            foreach (NvrInfo nvrInfo in serverApi.Nvr())
            {
                var nvr = Nvr(nvrInfo);
            }
            foreach (CameraInfo camera in serverApi.Camera())
            {
                var nvr = _nvrMapById[camera.nvr];
                var cam = nvr.Camera(camera);
                CameraList.Add(cam);
                _cameraMap.Add(camera.id, cam);
            }

            Task.Factory.StartNew(() =>
            {
                while (!_nvrMap.Values.All(nvr => nvr.Login()))
                {
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                }
            });
        }
        
        private void DisConnectCallBack(IntPtr LoginID, IntPtr DVRIP, int DVRPort, IntPtr dwUser)
        {
            try
            {
                var dvrIp = Marshal.PtrToStringAnsi(DVRIP);
                Log.Info("NETClient.Disconnect callback {0} {1} {2}", LoginID, dvrIp, dwUser);
                var ip = IPAddress.Parse(dvrIp);
                var address = new IPEndPoint(ip, DVRPort);
                var nvr = _nvrMap[address];
                nvr?.Disconnected();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString(), e);
            }
        }

        private void ReConnectCallBack(IntPtr LoginID, IntPtr DVRIP, int DVRPort, IntPtr dwUser)
        {
            try
            {
                var dvrIp = Marshal.PtrToStringAnsi(DVRIP);
                Log.Info("NETClient.ReConnect callback {0} {1} {2}", LoginID, dvrIp, dwUser);
                var ip = IPAddress.Parse(dvrIp);
                var address = new IPEndPoint(ip, DVRPort);
                var nvr = _nvrMap[address];
                nvr?.Connected();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString(), e);
            }
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
                var nvrController = _nvrMap[key];
                _nvrMapById.Add(nvr.id, nvrController);
                return nvrController;
            }
            else
            {
                var nvrController = new NvrController(nvr);
                _nvrMap.Add(key, nvrController);
                _nvrMapById.Add(nvr.id, nvrController);
                return nvrController;
            }
        }

        internal void Dispose()
        {
            foreach (var nvr in _nvrMap.Values)
                nvr.Disconnect();

            Log.Info("NETClient.Cleanup");
            NETClient.Cleanup();
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool SetDllDirectory(string lpPathName);
    }
}
