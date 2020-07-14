using api.dto;
using model.camera;
using System.Collections.Generic;

namespace service
{
    public class CameraService
    {
        private Dictionary<long, CameraController> CameraMap;

        public List<CameraController> CameraList
        {
            get
            {
                return new List<CameraController>(CameraMap.Values);
            }
        }

        public CameraService(NvrService nvrService, List<CameraInfo> list)
        {
            CameraMap = new Dictionary<long, CameraController>();
            foreach (CameraInfo camera in list)
            {
                var nvr = nvrService.Login(camera.NvrInfo);
                CameraMap.Add(camera.Id, nvr.Camera(camera.Chanel));
            }
        }
    }
}
