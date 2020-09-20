﻿using api;
using api.dto;
using gui;
using model.nvr;
using model.video;
using service;
using System;
using System.Collections.Generic;
using System.Linq;
using NetSDKCS;
using SDK_HANDLE = System.Int32;
using System.Threading.Tasks;
using System.Threading;

namespace model.camera
{
    public class CameraController
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private CameraModel model;
        private bool select;
        private Dictionary<ICameraView, CameraSreamModel> streams;

        public double Ratio {
            get => model.Ratio;
            set => model.Ratio = value;
        }

        public bool Selected
        {
            get
            {
                return select;
            }
            set
            {
                lock (streams)
                {
                    foreach (var kv in streams)
                        kv.Key.Selected = value;
                }
                select = value;
            }
        }

        public string Name => model.Name;
        public string Stand => model.Stand;

        public CameraController(NvrModel model, CameraInfo info)
        {
            this.model = new CameraModel(model, info);
            streams = new Dictionary<ICameraView, CameraSreamModel>();
        }

        internal void StartPlay(ICameraView view)
        {
            CameraSreamModel stream = new CameraSreamModel(model, view.Canvas);
            Log.Debug("{0}: add stream view", stream);

            lock (streams)
            {
                view.Selected = select;
                streams.Add(view, stream);
            }
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
                    view.Selected = false;
                    view.Canvas.Invalidate();
                    Log.Debug("{0}: remove stream view", stream);
                }
            }
        }

        internal List<VideoFileModel> SearchVideoFiles(DateTime day, EM_QUERY_RECORD_TYPE type)
        {
            DateTime from = day.Date.AddSeconds(1);
            DateTime to = day.Date.AddDays(1).AddSeconds(-1);
            return SearchVideoFiles(from, to, type);
        }

        internal List<VideoFileModel> SearchVideoFiles(DateTime from, DateTime to, EM_QUERY_RECORD_TYPE type)
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
            return model.Talk;
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

        internal void Ptz(EM_EXTPTZ_ControlType cmd, bool stop)
        {
            model.Ptz(cmd, stop, 4);
        }

        internal void Preset(int val)
        {
            model.Ptz(EM_EXTPTZ_ControlType.POINT_MOVE_CONTROL, false, val);
        }

        public override string ToString()
        {
            return model.Name;
        }

        public void StopPlay()
        {
            lock (streams)
            {
                foreach (var kv in streams)
                {
                    kv.Value.StopPlay();
                    kv.Value.Disconnected();
                    kv.Key.Canvas.Invalidate();
                }
            }
        }

        public void StartPlay()
        {
            lock (streams)
            {
                foreach (var kv in streams)
                {
                    kv.Value.StartPlay();
                }
            }
        }
    }
}
