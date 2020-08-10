using Flyway.net;
using Flyway.net.OptionGroups;
using SafeServer.service;
using System.IO;

namespace SafeServer
{
    public class DI
    {
        public static DI Instance { get; } = new DI();

        public void Init()
        {
        }

        internal void Dispose()
        {
            
        }
    }
}
