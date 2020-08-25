using System;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public interface IDevice
    {
        long Id();

        void Init();

        void Close();
        
        IObservable<DeviceStatus> Status();
    }
}
