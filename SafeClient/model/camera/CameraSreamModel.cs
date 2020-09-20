using api;
using System;
using System.Threading;
using System.Windows.Forms;
using NetSDKCS;
using SDK_HANDLE = System.Int32;

namespace model.camera
{
    public class CameraSreamModel
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private CameraModel camera;
        private IntPtr canvas;
        private volatile IntPtr playHandleId;
        private bool sound;
        private EM_RealPlayType stream;

        public bool Sound
        {
            get
            {
                return sound;
            }
        }

        public int Stream
        {
            get => stream == EM_RealPlayType.Realplay_0 ? 0 : 1;
            set => stream = value == 0 ? EM_RealPlayType.Realplay_0 : EM_RealPlayType.Realplay_1;
        }

        public bool StartedPlay
        {
            get
            {
                return playHandleId != IntPtr.Zero;
            }
        }

 
        public CameraSreamModel(CameraModel camera, PictureBox canvas)
        {
            this.camera = camera;
            this.canvas = canvas.Handle;
            stream = EM_RealPlayType.Realplay_1;
        }

        public void StartPlay()
        {
            if (playHandleId != IntPtr.Zero)
                return;

            Log.Debug("{0}: start play live video", this);
            playHandleId = NETClient.StartRealPlay(camera.LoginId, camera.Channel, canvas, stream, null, null, IntPtr.Zero, 5000);
            if (playHandleId != IntPtr.Zero)
            {
                Log.Info("{0}: NETClient.StartRealPlay - OK", this);
            }
            else
            {
                var error = NETClient.GetLastError();
                Log.Info("{0}: NETClient.StartRealPlay -  FAIL {1}", this, error);
            }
        }

        public void StopPlay()
        {
            camera.StopTalk();
            if (playHandleId != IntPtr.Zero)
            {
                Log.Info("{0}: NETClient.StopRealPlay - {1}", this, NETClient.StopRealPlay(playHandleId));
                playHandleId = IntPtr.Zero;
            }
        }

        public void OpenSound()
        {
            Log.Debug("{0}: open sound", this);
            Log.Info("{0}: NETClient.OpenSound - {1}", this, NETClient.OpenSound(playHandleId));
            sound = true;
        }

        public void CloseSound()
        {
            if (sound)
            {
                Log.Debug("{0}: close sound", this);
                Log.Info("{0}: NETClient.CloseSound - {1}", this, NETClient.CloseSound());
                sound = false;
            }
        }

        public override string ToString()
        {
            return camera.ToString();
        }

        public void Disconnected()
        {
            playHandleId = IntPtr.Zero;
            sound = false;
        }
    }
}
