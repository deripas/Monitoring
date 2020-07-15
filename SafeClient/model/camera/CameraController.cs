using gui;
using model.nvr;
using service;
using System;
using System.Collections.Generic;
using System.Xml;

namespace model.camera
{
    public class CameraController
    {
        private CameraModel model;
        private Dictionary<ICameraView, CameraSreamModel> streams;

        public CameraController(NvrModel model, int chanel)
        {
            this.model = new CameraModel(model, chanel);
            streams = new Dictionary<ICameraView, CameraSreamModel>();
        }

        internal void StartPlay(ICameraView view)
        {
            CameraSreamModel stream = new CameraSreamModel(model, view.Canvas());
            streams.Add(view, stream);
            stream.StartPlay();
        }

        internal void StopPlay(ICameraView view)
        {
            streams[view]?.StopPlay();
            streams.Remove(view);
        }

        internal bool Sound(CameraViewPanel view)
        {
            return streams[view]?.Sound == true;
        }

        internal void OpenSound(CameraViewPanel view)
        {
            DI.Instance.NvrService.CloseSound();
            DI.Instance.NvrService.StopTalk();
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
            DI.Instance.NvrService.CloseSound();
            DI.Instance.NvrService.StopTalk();
            model.StartTalk();
        }

        internal void StopTalk()
        {
            model.StopTalk();
        }

        internal void SetStream(CameraViewPanel view, int streamNum)
        {
            if(streams.ContainsKey(view))
            {
                var stream = streams[view];
                stream.StopPlay();
                stream.Stream = streamNum;
                stream.StartPlay();
            }
        }

        internal int GetStream(CameraViewPanel view)
        {
            return streams[view].Stream;
        }

        internal void Disconnect()
        {
            foreach (var kv in streams)
                Disconnect(kv);
        }

        private void Disconnect(KeyValuePair<ICameraView, CameraSreamModel> kv)
        {
            kv.Value.StopPlay();
            kv.Key.Disconnect();
        }

        internal void Check()
        {
            foreach (var kv in streams)
            {
                if (!kv.Value.Play)
                {
                    if (kv.Value.StartPlay())
                        kv.Key.Connect();
                }
                else
                {
                    if ((DateTime.Now - kv.Value.LastTime).TotalSeconds > 3)
                        Disconnect(kv);
                }
            }
        }

        public override string ToString()
        {
            return model.ToString();
        }
    }
}
