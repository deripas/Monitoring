using api.dto;
using System.Collections.Generic;

namespace api
{
    public interface IServerApi
    {
        List<CameraInfo> Cameras();
    }
}
