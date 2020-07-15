using api.dto;
using model.camera;
using System;
using System.Collections.Generic;
using System.Threading;

namespace model.nvr
{
    public class NvrController
    {
        private NvrModel model;
        private List<CameraController> cameras;
        private Timer timer;
        private DateTime time;

        public NvrController(NvrInfo nvr)
        {
            time = DateTime.Now;
            this.model = new NvrModel(nvr);
            cameras = new List<CameraController>();
            model.Login();
            timer = new Timer(TimerCallback, this, 5000, 5000);
        }

        private void TimerCallback(object state)
        {
            if (model.LoginId > 0)
            {
                time = DateTime.Now;
                foreach (var cam in cameras)
                    cam.Check();
            }
            else
            {
                if((DateTime.Now - time).TotalSeconds> 10)
                {
                    time = DateTime.Now;
                    model.Login();
                }
            }
        }

        internal CameraController Camera(int chanel)
        {
            CameraController camera = new CameraController(model, chanel);
            cameras.Add(camera);
            return camera;
        }

        internal void StartTalk()
        {
            model.StartTalk();
        }

        internal void StopTalk()
        {
            model.StopTalk();
        }

        internal void CloseSound()
        {
            foreach (var cam in cameras)
                cam.CloseSound();
        }

        internal void Disconnect()
        {
            foreach (var cam in cameras)
                cam.Disconnect();

            model.Logout();
        }
    }
}
