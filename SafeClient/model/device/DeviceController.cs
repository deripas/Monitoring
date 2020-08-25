using api.dto;
using model.camera;
using service;
using System;

namespace model.device
{
    public class DeviceController
    {
        private DeviceInfo info;
        private SensorView view;

        public int Id
        {
            get
            {
                return info.id;
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
        }

        public bool Enable
        {
            get
            {
                return info.enable && info.config != null;
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
            view?.GetControl().Invoke(new Action(() => view.Update(status)));
        }

        public void RolletUp()
        {
            DI.Instance.DeviceService.RolletUp(info.id);
        }

        public void RolletDown()
        {
            DI.Instance.DeviceService.RolletDown(info.id);
        }
    }
}
