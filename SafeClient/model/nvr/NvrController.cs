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
        private DateTime time;

        public NvrController(NvrInfo nvr)
        {
            time = DateTime.MinValue;
            model = new NvrModel(nvr);
            cameras = new List<CameraController>();
        }


        internal void Check()
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

        internal CameraController Camera(CameraInfo info)
        {
            CameraController camera = new CameraController(model, info);
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
                foreach (var cam in cameras)
                    cam.CloseSound();
        }

        internal void Disconnect()
        {
            Disconnect(true);
        }

        internal void Disconnect(bool full)
        {
            lock (model)
            {
                if (full)
                {
                    foreach (var cam in cameras)
                        cam.Disconnect();
                }

                model.Logout();
                cameras.Clear();
                time = DateTime.Now;
            }
        }
    }
}
