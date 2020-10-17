namespace model.video
{
    using NetSDKCS;
    using System;
    using SDK_HANDLE = System.Int32;

    public interface VideoPlayBackSource
    {
        DateTime BeginTime { get; }
        DateTime EndTime { get; }
        string Name { get; }
        double Ratio { get; }
        
        IntPtr Play(IntPtr canvas, DateTime startTime, DateTime endTime);

        IntPtr Export(string file, DateTime startTime, DateTime endTime, fTimeDownLoadPosCallBack callBack);
    }
}
