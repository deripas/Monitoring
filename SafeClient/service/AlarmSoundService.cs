using NAudio.Wave;
using Properties;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace service
{
    public class AlarmSoundService
    {
        private WaveOutEvent output;

        public AlarmSoundService()
        {
            var wav = new RawSourceWaveStream(Resources.sirena, new WaveFormat(44100, 16, 2));
            output = new WaveOutEvent();
            output.Init(wav);
        }

        public void Play()
        {
            output.Play();
        }

        public void Stop()
        {
            output.Stop();
        }

        internal void Dispose()
        {
            Stop();
        }
    }
}
