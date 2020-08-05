using System;

namespace model.video
{
    [Flags]
    enum FileAlertType
    {
        None = 0,
        All = ~0,
        Alarm = 1,
        Detect = 2,
        Regular = 4,
        Manual = 8
    }
}
