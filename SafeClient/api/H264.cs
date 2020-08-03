using System;
using System.Runtime.InteropServices;

namespace api
{
    public class H264
    {
        public static int STREAME_REALTIME = 0;

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_OpenStream(Int32 nPort, IntPtr pFileHeadBuf, UInt32 nSize, UInt32 nBufPoolSize);

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_OpenFile(Int32 nPort, [MarshalAs(UnmanagedType.LPStr)] String sFileName);

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_SetStreamOpenMode(Int32 nPort, Int32 nMode);

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_Play(Int32 nPort, IntPtr hWnd);

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_PlaySound(Int32 nPort);

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_PlaySoundShare(Int32 nPort);

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_InputData(Int32 nPort, IntPtr pBuf, UInt32 nSize);

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_CloseStream(Int32 nPort);

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_Stop(Int32 nPort);

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_StopSound();

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_StopSoundShare(Int32 nPort);

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_StartDataRecord(Int32 nPort, [MarshalAs(UnmanagedType.LPStr)] String sFileName, MEDIA_FILE_TYPE nType);

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_StopDataRecord(Int32 nPort);

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_Fast(Int32 nPort);

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_Slow(Int32 nPort);

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_Pause(Int32 nPort, bool nPause);

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_NextFrame(Int32 nPort);

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_PrevFrame(Int32 nPort);

        [DllImport("H264Play.dll")]
        public static extern UInt32 H264_PLAY_GetPlayedTimeEx(Int32 nPort);

        [DllImport("H264Play.dll")]
        public static extern UInt32 H264_PLAY_GetPlayedFrames(Int32 nPort);

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_SetPlayedTimeEx(Int32 nPort, UInt32 nFrameNum);

        [DllImport("H264Play.dll")]
        public static extern UInt32 H264_PLAY_GetCurrentFrameNum(Int32 nPort);

        [DllImport("H264Play.dll")]
        public static extern UInt32 H264_PLAY_GetFileTotalFrames(Int32 nPort);

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_SetCurrentFrameNum(Int32 nPort, UInt32 nFrameNum);

        [DllImport("H264Play.dll")]
        public static extern UInt32 H264_PLAY_GetFileHeadLength();

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_SetPlayPos(Int32 nPort, float fRelativePos);

        [DllImport("H264Play.dll")]
        public static extern float H264_PLAY_GetPlayPos(Int32 nPort);

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_RefreshPlay(Int32 nPort);

        [DllImport("H264Play.dll")]
        public static extern bool H264_PLAY_ResetSourceBuffer(Int32 nPort);

        [DllImport("H264Play.dll")]
        public static extern Int32 H264_PLAY_GetLastError(Int32 nPort);

        [DllImport("H264Play.dll")]
        public static extern UInt32 H264_PLAY_GetPlayFPS(Int32 nPort);
    }
}
