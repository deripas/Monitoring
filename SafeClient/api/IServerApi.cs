using api.dto;
using System;
using System.Collections.Generic;

namespace api
{
    public interface IServerApi
    {
        List<NvrInfo> Nvr();

        List<CameraInfo> Camera();

        List<DeviceInfo> Device();

        List<AlertInfo> Alerts(DateTime from, DateTime to);

        List<AlertInfo> Alerts(int device, DateTime from, DateTime to);

        List<SensorStatus> Statuses();
    }
}
