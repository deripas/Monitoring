using SafeServer.dto;
using SafeServer.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.service
{
    public class CameraService
    {
        public Camera this[int id] => map[id];
        private Dictionary<int, Camera> map;

        public CameraService()
        {
            map = new Dictionary<int, Camera>();
        }

        public void Init()
        {
            using var db = new DatabaseService();
            map = db.Camera.ToDictionary(c => c.Id);
        }

        internal void Dispose()
        {
            
        }
    }
}
