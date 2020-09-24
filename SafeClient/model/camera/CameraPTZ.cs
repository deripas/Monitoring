using NetSDKCS;
using onvif20_ptz;
using System;
using System.ServiceModel;

namespace model.camera
{
    public class CameraPTZ
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();


        private IntPtr LoginId;
        private int Channel;
        private string Profile;
        private PTZClient PTZClient;

        public CameraPTZ(IntPtr loginId, int channel, string profile, string uri)
        {
            this.LoginId = loginId;
            this.Channel = channel;
            this.Profile = profile;

            try
            {
                if (profile != null && uri != null)
                    PTZClient = new PTZClient(CameraModel.BINDING, new EndpointAddress(uri));
            }
            catch (Exception e)
            {
                Log.Warn("{0}: PTZClient error create", this, e);
            }
        }

        public void Ptz(EM_EXTPTZ_ControlType cmd, bool stop, int speed)
        {
            var result = NETClient.PTZControl(LoginId, Channel, cmd, 0, speed, 0, stop, IntPtr.Zero);
            Log.Debug("{0}: NETClient.PTZControl cmd={1} value={2} {3}", this, cmd, speed, result);
        }

        public void Preset(int val)
        {
            try
            {
                PTZClient.GotoPreset(new GotoPresetRequest(Profile, val.ToString(), null));
                Log.Debug("{0}: PTZClient GotoPreset {1}", this, val);
            }
            catch (Exception e)
            {
                var result = NETClient.PTZControl(LoginId, Channel, EM_EXTPTZ_ControlType.POINT_MOVE_CONTROL, 0, val, 0, false, IntPtr.Zero);
                Log.Debug("{0}: NETClient.PTZControl cmd={1} value={2} {3}", this, EM_EXTPTZ_ControlType.POINT_MOVE_CONTROL, val, result);
            }
        }

        internal void Close()
        {
            try
            {
                PTZClient?.Close();
                Log.Debug("{0}: PTZClient Close", this);
            }
            catch (Exception e)
            {
                Log.Warn("{0}: PTZClient Error Close", this);
            }
        }

        public override string ToString()
        {
            return "PTZ";
        }
    }
}
