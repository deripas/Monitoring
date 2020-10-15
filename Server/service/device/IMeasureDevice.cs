using SafeServer.dto;
using System;

namespace SafeServer.service.device
{
    public interface IMeasureDevice 
    {
        IObservable<DeviceStatus> Status();
    }
}