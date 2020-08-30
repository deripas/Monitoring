using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace api.dto
{
    public class CameraGrid
    {
        public int rows { get; set; }
        public int cols { get; set; }
        public List<int> cams { get; set; }


        public static CameraGrid grid6x6()
        {
            List<int> cams = new List<int>{ 29, 30, 0, 31, 32, 33, 24, 25, 26, 27, 0, 28, 20, 21, 22, 23, 16, 17, 12, 13, 14, 15, 18, 19, 5, 7, 8, 9, 10, 11, 1, 2, 3, 0, 4, 6 };

            return new CameraGrid()
            {
                cols = 6,
                rows = 6,
                cams = cams
            };
        }

        public static CameraGrid grid3x3_1()
        {
            List<int> cams = new List<int> { 31, 32, 26, 3, 2, 1, 4, 6, 16 };

            return new CameraGrid()
            {
                cols = 3,
                rows = 3,
                cams = cams
            };
        }

        public static CameraGrid grid3x3_2()
        {
            List<int> cams = new List<int> { 31, 32, 26, 18, 19, 17, 4, 6, 16 };

            return new CameraGrid()
            {
                cols = 3,
                rows = 3,
                cams = cams
            };
        }

        public static CameraGrid grid3x3_3()
        {
            List<int> cams = new List<int> { 31, 32, 26, 3, 2, 1, 4, 6, 16 };

            return new CameraGrid()
            {
                cols = 3,
                rows = 3,
                cams = cams
            };
        }
    }
}
