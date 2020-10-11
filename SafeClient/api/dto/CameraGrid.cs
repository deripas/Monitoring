using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace api.dto
{
    public class CameraGrid
    {
        public int stream { get; set; }
        public int rows { get; set; }
        public int cols { get; set; }
        public List<int> cams { get; set; }
        public List<int> device { get; set; }
        public List<int> control { get; set; }


        public static CameraGrid grid1x1(int camera, int stream)
        {
            List<int> cams = new List<int> { camera };
            List<int> dev = new List<int> { };
            List<int> control = new List<int>() {  };

            return new CameraGrid()
            {
                cols = 1,
                rows = 1,
                cams = cams,
                device = dev,
                control = control,
                stream = stream 
            };
        }
    }
}
