using api.dto;
using model.camera;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace model.nvr
{
    public class NvrController
    {
        private NvrModel model;
        private List<CameraController> cameras;

        private volatile bool connect;
        private Task checker;

        public NvrController(NvrInfo nvr)
        {
            model = new NvrModel(nvr);
            cameras = new List<CameraController>();
        }


        internal bool Login()
        {
            var login = model.Login();
            if (login) Connected();
            return login;
        }

        internal CameraController Camera(CameraInfo info)
        {
            CameraController camera = new CameraController(model, info);
            cameras.Add(camera);
            return camera;
        }

        internal void CloseSound()
        {
            lock (model)
                foreach (var cam in cameras)
                    cam.CloseSound();
        }

        internal void Disconnect()
        {
            connect = false;
            if (checker != null) Task.WaitAll(checker);
            checker = null;

            lock (model)
            {
                model.Logout();
            }
        }

        public void Disconnected()
        {
            connect = false;
            if (checker != null) Task.WaitAll(checker);
            checker = null;

            lock (model)
                foreach (var cam in cameras)
                    cam.StopPlay();
        }

        public void Connected()
        {
            if (checker != null) return;

            connect = true;
            checker = Task.Factory.StartNew(() =>
            {
                while (connect)
                {
                    lock (model)
                        foreach (var cam in cameras)
                            cam.StartPlay();
                    Thread.Sleep(500);
                }
            });
        }
    }
}
