namespace model.video
{
    using System;
    using SDK_HANDLE = System.Int32;

    public interface VideoPlayBackSource
    {
        SDK_HANDLE Play(IntPtr canvas);
    }
}
