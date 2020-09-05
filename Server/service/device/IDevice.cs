using System;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public interface IDevice
    {
        long Id();

        int? CameraId();

        string Name();

        void Init();

        void Close();
        
        IObservable<DeviceStatus> Status();

        string RenderStatusValue(DeviceStatus status);
        void Update(Config cfg);
    }
}
