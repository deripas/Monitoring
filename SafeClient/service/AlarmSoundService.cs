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
        private volatile bool play;

        public AlarmSoundService()
        {
            output = new WaveOutEvent();
        }

        public void Play()
        {
            if (!play)
            {
                play = true;
                var waveStream = new RawSourceWaveStream(Resources.sirena, new WaveFormat(44100, 16, 2));
                output.Init(waveStream);
                output.Play();
            }
        }

        public void Stop()
        {
            output.Stop();
            play = false;
        }

        internal void Dispose()
        {
            Stop();
        }
    }
}
