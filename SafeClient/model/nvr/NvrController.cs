﻿using api.dto;
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
            time = DateTime.MinValue;
            this.model = new NvrModel(nvr);
            cameras = new List<CameraController>();
            timer = new Timer(TimerCallback, this, 1000, 200);
        }

        private void TimerCallback(object state)
        {
            lock (model)
            {
                if (model.LoginId > 0)
                {
                    foreach (var cam in cameras)
                        cam.Check();
                }
                else
                {
                    if ((DateTime.Now - time).TotalSeconds > 10)
                    {
                        model.Login();
                        time = DateTime.Now;
                    }
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
            lock (model)
                model.StartTalk();
        }

        internal void StopTalk()
        {
            lock (model)
                model.StopTalk();
        }

        internal void CloseSound()
        {
            lock (model)
            {
                foreach (var cam in cameras)
                    cam.CloseSound();
            }
        }

        internal void Disconnect()
        {
            lock (model)
            {
                foreach (var cam in cameras)
                    cam.Disconnect();

                model.Logout();
                time = DateTime.Now;
            }
        }
    }
}
