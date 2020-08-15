using System;

namespace SafeServer.service.device
{
    public interface ISirenDevice : IDevice
    {
        void Subscribe(IObservable<bool> siren);
    }
}