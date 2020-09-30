using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace api.dto.client
{
    public class ClientTypeFactory
    {
        public ClientType Create()
        {
            var type = ConfigurationManager.AppSettings["client.type"];
            switch (type)
            {
                case "view":
                    return new ClientTypeView();
                case "stand:bks":
                    return new ClientTypeStand("bks");
                case "stand:mks":
                    return new ClientTypeStand("mks");
                case "stand:kes":
                    return new ClientTypeStand("kes");

                default: throw new Exception("Неизвестный тип клиента: " + type);
            }
        }
    }
}
