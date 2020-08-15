using System;

namespace SafeServer.service.device
{
    public interface IWithSirenDevice : IDevice
    {
        long SirenId();
        
        IObservable<bool> Siren();
    }
}