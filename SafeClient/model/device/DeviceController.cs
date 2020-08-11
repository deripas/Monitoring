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

        public DeviceController(DeviceInfo info)
        {
            this.info = info;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
