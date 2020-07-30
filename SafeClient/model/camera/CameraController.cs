using api;
using gui;
using model.nvr;
using model.video;
using service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace model.camera
{
    public class CameraController
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private CameraModel model;
        private Dictionary<ICameraView, CameraSreamModel> streams;

        public CameraController(NvrModel model, int chanel)
        {
            this.model = new CameraModel(model, chanel);
            streams = new Dictionary<ICameraView, CameraSreamModel>();
        }

        internal void StartPlay(ICameraView view)
        {
            CameraSreamModel stream = new CameraSreamModel(model, view.Canvas);
            Log.Debug("{0}: add stream view", stream);

            lock (streams)
                streams.Add(view, stream);
        }

        internal void StopPlay(ICameraView view)
        {
            lock (streams)
            {
                if (streams.ContainsKey(view))
                {
                    var stream = streams[view];
                    lock (stream)
                        stream.StopPlay();

                    streams.Remove(view);
                    view.Canvas.Invalidate();
                    Log.Debug("{0}: remove stream view", stream);
                }
            }
        }

        internal List<VideoFileModel> SearchVideo(DateTime date, FileAlertType type)
        {
            var result = new List<VideoFileModel>();
            if (type.HasFlag(FileAlertType.Alarm))
                result.AddRange(SearchVideo(date, FileType.SDK_RECORD_ALARM));
            if (type.HasFlag(FileAlertType.Detect))
                result.AddRange(SearchVideo(date, FileType.SDK_RECORD_DETECT));
            if (type.HasFlag(FileAlertType.Regular))
                result.AddRange(SearchVideo(date, FileType.SDK_RECORD_REGULAR));
            if (type.HasFlag(FileAlertType.Manual))
                result.AddRange(SearchVideo(date, FileType.SDK_RECORD_MANUAL));
            
            result.Sort((x, y) => DateTime.Compare(x.BeginTime, y.BeginTime)); 
            return result;
        }

        internal List<VideoFileModel> SearchVideo(DateTime date, FileType type)
        {
            H264_DVR_TIME startTime = new H264_DVR_TIME();
            startTime.dwYear = date.Year;
            startTime.dwMonth = date.Month;
            startTime.dwDay = date.Day;
            startTime.dwHour = 0;
            startTime.dwMinute = 0;
            startTime.dwSecond = 0;

            H264_DVR_TIME endTime = new H264_DVR_TIME();
            endTime.dwYear = startTime.dwYear;
            endTime.dwMonth = startTime.dwMonth;
            endTime.dwDay = startTime.dwDay;
            endTime.dwHour = 23;
            endTime.dwMinute = 59;
            endTime.dwSecond = 59;

            var result = new List<VideoFileModel>();
            List<VideoFileModel> sub;
            do
            {
                sub = model.SearchVideo(startTime, endTime, type);
                result.AddRange(sub);

                if (sub.Count > 0) startTime = sub.Last().GetEndDvrTime();
            } while (sub.Count == 64);
            return result;
        }

        internal bool Sound(CameraViewPanel view)
        {
            return streams[view]?.Sound == true;
        }

        internal void OpenSound(CameraViewPanel view)
        {
            DI.Instance.CameraService.CloseSound();
            DI.Instance.CameraService.StopTalk();
            streams[view]?.OpenSound();
        }

        internal void CloseSound()
        {
            foreach (var camera in streams.Values)
                camera.CloseSound();
        }

        internal void CloseSound(CameraViewPanel view)
        {
            streams[view]?.CloseSound();
        }

        internal bool Talk()
        {
            return model.Talk == true;
        }

        internal void StartTalk()
        {
            DI.Instance.CameraService.CloseSound();
            DI.Instance.CameraService.StopTalk();
            model.StartTalk();
        }

        internal void StopTalk()
        {
            model.StopTalk();
        }

        internal void SetStream(CameraViewPanel view, int streamNum)
        {
            Log.Debug("{0}: change stream number to {1}", view, streamNum);
            if (streams.ContainsKey(view))
            {
                var stream = streams[view];
                lock (stream)
                {
                    stream.Stream = streamNum;
                    stream.StopPlay();
                    stream.StartPlay();
                }
            }
        }

        internal int GetStream(CameraViewPanel view)
        {
            return streams[view].Stream;
        }

        internal void Disconnect()
        {
            Log.Debug("{0}: disconnect", model);

            foreach (var kv in streams)
                StopPlay(kv);
        }

        private void StopPlay(KeyValuePair<ICameraView, CameraSreamModel> kv)
        {
            kv.Value.StopPlay();
            kv.Value.ResetTime();
            kv.Key.Canvas.Invalidate();
        }

        internal void Check()
        {
            lock (streams)
            {
                foreach (var kv in streams)
                {
                    lock (kv.Value)
                    {
                        if (!kv.Value.StartedPlay)
                        {
                            if ((DateTime.Now - kv.Value.LastUpdateTime).TotalSeconds > 10)
                            {
                                kv.Value.StartPlay();
                            }
                        }
                        else
                        {
                            if ((DateTime.Now - kv.Value.LastUpdateTime).TotalSeconds > 5)
                            {
                                StopPlay(kv);
                            }
                        }
                    }
                }
            }
        }

        internal void Ptz(PTZ_ControlType cmd, bool stop)
        {
            model.Ptz(cmd, stop, 4);
        }

        public override string ToString()
        {
            return model.ToString();
        }
    }
}
