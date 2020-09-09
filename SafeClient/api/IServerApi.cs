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
        DeviceInfo DeviceSingle(int id);

        void DeviceConfig(int id, Config cfg);

        List<AlertInfo> Alerts(DateTime from, DateTime to);

        List<AlertInfo> Alerts(int device, DateTime from, DateTime to);

        void ProcessAlert(long id);
        void ProcessAlertAll(long id);
        CountResult FindAlertAll(long id);
        CountResult FindAlertAll();
        AlertInfo FindLastAlert(bool processed);

        void ResetDevice(long id);
        void ResetDeviceAlert(long id);

        List<PointD> DeviceData(int device, DateTime from, DateTime to);

        List<SensorStatus> Statuses();

        void RolletUp(int device);
        void RolletDown(int device);
        void RolletStop(int device);

        void HurbleOn(int device);
        void HurbleOff(int device);
        void HurbleAuto(int device);
       
    }
}
