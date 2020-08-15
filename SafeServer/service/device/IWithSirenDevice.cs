namespace SafeServer.service.device
{
    public interface IWithSirenaDevice : IDevice
    {
        long SirenaId();
    }
}