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
using onvif20_ptz;
using onvif.services;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Net;
using onvif10_device;
using onvif10_media;
using System.Windows.Forms.VisualStyles;
using System.Threading.Tasks;

namespace model.camera
{
    public class CameraModel
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();


        public static readonly HttpTransportBindingElement HTTP_BINDING = new HttpTransportBindingElement
        {
            AuthenticationScheme = AuthenticationSchemes.Digest
        };
        public static readonly TextMessageEncodingBindingElement TXT_BINDING = new TextMessageEncodingBindingElement
        {
            MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None)
        };
        public static readonly CustomBinding BINDING = new CustomBinding(TXT_BINDING, HTTP_BINDING);

        private NvrModel nvr;
        private double ratio = 9D / 16D;

        public int Channel { get; }

        public int Id { get; }
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

        private volatile bool started;
        private volatile String Profile;
        private volatile Service ptzService;

        public CameraModel(NvrModel nvr, CameraInfo info)
        {
            this.nvr = nvr;
            this.Channel = info.channel - 1;
            Id = info.id;
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

        public override string ToString()
        {
            return "cam(" + nvr.Ip + " #" + (Channel + 1) + ")";
        }

        internal List<VideoFileModel> SearchVideoFiles(System.DateTime from, System.DateTime to, EM_QUERY_RECORD_TYPE type)
        {
            return SearchVideoFilesBatch(from, to, type);
        }

        private List<VideoFileModel> SearchVideoFilesBatch(System.DateTime from, System.DateTime to, EM_QUERY_RECORD_TYPE fileType)
        {
            int fileCount = 0;
            NET_RECORDFILE_INFO[] recordFileArray = new NET_RECORDFILE_INFO[5000];
            bool ret = QueryFile(from, to, fileType, ref recordFileArray, ref fileCount);
            Log.Debug("{0}: NETClient.QueryRecordFile code={1}, count={2}", this, ret, fileCount);
            return ToList(recordFileArray, fileCount);
        }

        private bool QueryFile(System.DateTime startTime, System.DateTime endTime, EM_QUERY_RECORD_TYPE nRecordFileType, ref NET_RECORDFILE_INFO[] infos, ref int fileCount)
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

        internal VideoTimeRangeModel SearchVideo(System.DateTime from, System.DateTime to)
        {
            return new VideoTimeRangeModel(this, from, to);
        }

        internal void Start()
        {
            if (started) return;
            started = true;
            Task.Factory.StartNew(() =>
            {
                string ip = "NA";
                try
                {
                    var info = nvr.CamerasInfo[Channel];
                    ip = info.stuRemoteDevice.szIp;
                    string url = string.Format("http://{0}/onvif/device_service", ip);
                    EndpointAddress DeviceServiceRemoteAddress = new EndpointAddress(url);
                    DeviceClient Client = new DeviceClient(BINDING, DeviceServiceRemoteAddress);
                    try
                    {
                        var services = Client.GetServices(new GetServicesRequest());

                        ptzService = services.Service.Where(x => x.XAddr.ToLower().Contains("ptz")).First();
                        var mediaServiceInfo = services.Service.Where(x => x.XAddr.ToLower().Contains("media")).First();

                        MediaClient media = new MediaClient(BINDING, new EndpointAddress(mediaServiceInfo.XAddr));
                        try
                        {
                            var profiles = media.GetProfiles(new GetProfilesRequest());
                            Profile = profiles.Profiles[0].token;
                        }
                        finally
                        {
                            media.Close();
                        }
                    }
                    finally
                    {
                        Client.Close();
                    }
                }
                catch (Exception e)
                {
                    Log.Warn("{0}: error onvif ip={1}", this, ip, e);
                }
            });
        }

        internal void Stop()
        {
            started = false;
        }

        internal CameraPTZ PTZ()
        {
            return new CameraPTZ(LoginId, Channel, Profile, ptzService?.XAddr);
        }
    }
}
