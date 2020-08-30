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

        void ProcessAlert(long id);
        void ResetDevice(long id);
        void ResetDeviceAlert(long id);

        List<PointD> DeviceData(int device, DateTime from, DateTime to);

        List<SensorStatus> Statuses();

        void RolletUp(int device);
        void RolletDown(int device);
        void RolletStop(int device);
    }
}
