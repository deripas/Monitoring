﻿using api.dto;
using model.camera;
using service;
using System;

namespace model.device
{
    public class DeviceController
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private volatile DeviceInfo info;
        private SensorView view;

        public int Id
        {
            get
            {
                return info.id;
            }
        }

        public string Stand
        {
            get
            {
                return info.stand;
            }
        }

        public CameraController Camera
        {
            get
            {
                if (info.camera == null)
                    return null;

                return DI.Instance.CameraService[info.camera.Value];
            }
        }

        public SensorView View
        {
            get
            {
                return view;
            }
            set
            {
                if (view != null)
                    throw new Exception();
                view = value;
                value.Set(this);
            }
        }

        public DeviceType Type
        {
            get
            {
                return info.GetTypeEnum();
            }
        }

        public string Name
        {
            get
            {
                return info.name;
            }
        }

        public string Description
        {
            get
            {
                return info.description;
            }
            set
            {
                info.description = value;
            }
        }

        public bool Removed
        {
            get
            {
                return info.removed && info.config != null;
            }
            set
            {
                info.removed = value;
            }
        }

        public Config Config
        {
            get
            {
                return info.config;
            }
        }

        public DeviceController(DeviceInfo info)
        {
            this.info = info;
        }

        public override string ToString()
        {
            return Name;
        }

        public void Update(SensorStatus status)
        {
            if (view != null)
            {
                var c = view.GetControl();
                if (c.IsHandleCreated && c.Parent != null)
                    c.Invoke(new Action(() =>
                    {
                        try
                        {
                            view.Update(status);
                        }
                        catch (Exception e)
                        {
                            Log.Error(e, "error update");
                        }

                    }));
            }
        }

        public void RolletUp()
        {
            DI.Instance.DeviceService.RolletUp(info.id);
        }

        public void RolletDown()
        {
            DI.Instance.DeviceService.RolletDown(info.id);
        }

        public void RolletStop()
        {
            DI.Instance.DeviceService.RolletStop(info.id);
        }

        public void Refresh(Config config)
        {
            info.config = config;
            view?.Set(this);
        }
    }
}
