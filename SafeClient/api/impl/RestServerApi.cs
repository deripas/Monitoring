using Spring.Rest.Client;
using System.Configuration;

namespace api.impl
{
    class RestServerApi
    {
        private RestTemplate template;

        public RestServerApi()
        {
            template = new RestTemplate(ConfigurationManager.AppSettings["server.url"]);
        }

    }
}
