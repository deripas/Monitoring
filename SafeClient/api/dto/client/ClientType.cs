using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace api.dto
{
    public interface ClientType
    {
        CameraGrid[] GetMode();
        String GetTitle();
    }
}
