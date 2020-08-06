﻿using api;
using gui;
using model.nvr;
using model.video;
using service;
using System;
using System.Collections.Generic;
using System.Linq;
using SDK_HANDLE = System.Int32;

namespace model.camera
{
    public class CameraController
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private CameraModel model;
        private Dictionary<ICameraView, CameraSreamModel> streams;

        public double Ratio {
            get
            {
                return model.Ratio;
            }
            set
            {
                model.Ratio = value;
            }
        }

        public string Name => model.Name;

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

        internal List<VideoFileModel> SearchVideoFiles(DateTime day, FileAlertType type)
        {
            var result = new List<VideoFileModel>();
            if (type.HasFlag(FileAlertType.Alarm))
                result.AddRange(SearchVideoFiles(day, FileType.SDK_RECORD_ALARM));
            if (type.HasFlag(FileAlertType.Detect))
                result.AddRange(SearchVideoFiles(day, FileType.SDK_RECORD_DETECT));
            if (type.HasFlag(FileAlertType.Regular))
                result.AddRange(SearchVideoFiles(day, FileType.SDK_RECORD_REGULAR));
            if (type.HasFlag(FileAlertType.Manual))
                result.AddRange(SearchVideoFiles(day, FileType.SDK_RECORD_MANUAL));
            
            result.Sort((x, y) => DateTime.Compare(x.BeginTime, y.BeginTime)); 
            return result;
        }

        internal List<VideoFileModel> SearchVideoFiles(DateTime day, FileType type)
        {
            DateTime from = day.Date.AddSeconds(1);
            DateTime to = day.Date.AddDays(1).AddSeconds(-1);
            return SearchVideoFiles(from, to, type);
        }

        internal List<VideoFileModel> SearchVideoFiles(DateTime from, DateTime to, FileType type)
        {
            return model.SearchVideoFiles(from, to, type);
        }

        internal VideoTimeRangeModel SearchVideo(DateTime from, DateTime to)
        {
            return model.SearchVideo(from, to);
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

        internal void Preset(int val)
        {
            model.Ptz(PTZ_ControlType.EXTPTZ_POINT_MOVE_CONTROL, true, val);
        }

        public override string ToString()
        {
            return model.ToString();
        }
    }
}
