namespace SafeServer.service.device
{
    public interface IDevice
    {
        long Id();

        void Init();
        
        void Reset();

        void Close();
    }
}
