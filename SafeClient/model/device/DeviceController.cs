using api.dto;
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

        public bool Enable
        {
            get
            {
                return info.enable && info.config != null;
            }
            set
            {
                info.enable = value;
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
            var changed = info.version != status.version;
            if(changed)
            {
                info = DI.Instance.ServerApi.DeviceSingle(Id);
                Log.Info("device changed {}({})", info.name, info.id);
            }

            if (view != null)
            {
                var c = view.GetControl();
                if (c.IsHandleCreated && c.Parent != null)
                    c.Invoke(new Action(() =>
                    {
                        if (changed) view.Set(this);
                        if (Enable) view.Update(status);
                    }));
            }
        }

        public void RolletUp()
        {
            if (Enable)
                DI.Instance.DeviceService.RolletUp(info.id);
        }

        public void RolletDown()
        {
            if (Enable)
                DI.Instance.DeviceService.RolletDown(info.id);
        }

        public void RolletStop()
        {
            if (Enable)
                DI.Instance.DeviceService.RolletStop(info.id);
        }
    }
}
