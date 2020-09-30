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


        public static CameraGrid grid6x6()
        {
            List<int> cams = new List<int> { 29, 30, 0, 31, 32, 33, 24, 25, 26, 27, 0, 28, 20, 21, 22, 23, 16, 17, 12, 13, 14, 15, 18, 19, 5, 7, 8, 9, 10, 11, 1, 2, 3, 0, 4, 6 };
            List<int> dev = new List<int> { 47, 40, 46, 44, 45, 37, 36, 39, 38, 41, 43, 42, 24, 19, 18, 21, 20, 23, 22, 25, 27, 26 };
            List<int> control = new List<int>() { 67, 68, 59, 60, 57 };

            return new CameraGrid()
            {
                cols = 6,
                rows = 6,
                cams = cams,
                device = dev,
                control = control,
                stream = 1
            };
        }

        public static CameraGrid grid3x3_1()
        {
            List<int> cams = new List<int> { 31, 32, 26, 3, 2, 1, 4, 6, 16 };
            List<int> dev = new List<int> { 12, 9, 8, 15, 51, 53, 52, 41, 39, 40, 22, 23, 24, 21, 34 };
            List<int> control = new List<int>() { 67, 68, 59, 60, 57};

            return new CameraGrid()
            {
                cols = 3,
                rows = 3,
                cams = cams,
                device = dev,
                control = control,
                stream = 0
            };
        }

        public static CameraGrid grid3x3_2()
        {
            List<int> cams = new List<int> { 31, 32, 26, 18, 19, 17, 4, 6, 16 };
            List<int> dev = new List<int> { 12, 9, 8, 15, 1, 2, 3, 4, 5, 51, 53, 52, 41, 39, 40, 22, 23, 24, 21, 34 };
            List<int> control = new List<int>() { 67, 68, 59, 60, 57 };

            return new CameraGrid()
            {
                cols = 3,
                rows = 3,
                cams = cams,
                device = dev,
                control = control,
                stream = 1
            };
        }

        public static CameraGrid grid3x3_3()
        {
            List<int> cams = new List<int> { 31, 32, 26, 3, 2, 1, 4, 6, 16 };
            List<int> dev = new List<int> { 12, 9, 8, 15, 51, 53, 52, 41, 39, 40, 22, 23, 24, 21, 34 };
            List<int> control = new List<int>() { 67, 68, 59, 60, 57 };

            return new CameraGrid()
            {
                cols = 3,
                rows = 3,
                cams = cams,
                device = dev,
                control = control,
                stream = 1
            };
        }

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
