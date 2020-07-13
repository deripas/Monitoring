namespace api.dto
{
    public class CameraInfo
    {
        public long Id { get; set; }
        public string Ip { get; set; }
        public ushort Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Chanel { get; set; }

        public NvrInfo NvrInfo => new NvrInfo(Ip, Port, Login, Password);

        public CameraInfo()
        {
        }

        public CameraInfo(long id, string ip, ushort port, string login, string password, int chanel)
        {
            Id = id;
            Ip = ip;
            Port = port;
            Login = login;
            Password = password;
            Chanel = chanel;
        }

    }
}
