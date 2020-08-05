using api.dto;
using System;
using System.Collections.Generic;

namespace api
{
    public interface IServerApi
    {
        List<CameraInfo> Cameras();

        List<AlertInfo> Alerts(DateTime from, DateTime to);
    }
}
