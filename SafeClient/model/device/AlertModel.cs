﻿using api.dto;
using model.camera;
using model.video;
using System;
using System.Configuration;
using SDK_HANDLE = System.Int32;

namespace model.device
{
    public class AlertModel
    {
        public long ID
        {
            get
            {
                return info.id;
            }
        }
        public DateTime Time
        {
            get
            {
                return info.GetDateTime();
            }
        }        
        public double Value
        {
            get
            {
                return info.value;
            }
        }
        public bool Processed
        {
            get
            {
                return info.processed;
            }
            set
            {
                info.processed = value;
            }
        }

        public CameraController Camera;
        public DeviceController Device;
        private AlertInfo info;

        public AlertModel(CameraController camera, DeviceController device, AlertInfo info)
        {
            this.Camera = camera;
            this.Device = device;
            this.info = info;
        }

        public override string ToString()
        {
            return String.Format("[{0:HH:mm:ss}]", Time);
        }

        public VideoTimeRangeModel Video()
        {
            int AlertBeforeSec = int.Parse(ConfigurationManager.AppSettings["alert.before.sec"]);
            int AlertAfterSec = int.Parse(ConfigurationManager.AppSettings["alert.after.sec"]);

            DateTime from = Time.AddSeconds(-AlertBeforeSec);
            DateTime to = Time.AddSeconds(AlertAfterSec);
            return Camera.SearchVideo(from, to);
        }
    }
}
