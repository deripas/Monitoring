using System;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public interface ISensorDevice : IDevice
    {
        IObservable<SensorStatus> Status();
    }
}