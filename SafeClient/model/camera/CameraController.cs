using gui;
using model.nvr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            var stream = streams[view];
            streams.Remove(view);
            stream?.StopPlay();
        }
    }
}
