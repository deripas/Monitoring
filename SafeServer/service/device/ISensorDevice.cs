using System;

namespace SafeServer.service.device
{
    public interface IMeasureDevice : IDevice
    {
        public IObservable<Tuple<bool[], int>> Value;
    }
}