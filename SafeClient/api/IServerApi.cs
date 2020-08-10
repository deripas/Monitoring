using api.dto;
using System;
using System.Collections.Generic;

namespace api
{
    public interface IServerApi
    {
        List<NvrInfo> Nvr();

        List<CameraInfo> Camera();

        List<AlertInfo> Alerts(DateTime from, DateTime to);
    }
}
