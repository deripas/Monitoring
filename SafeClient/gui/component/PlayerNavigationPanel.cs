﻿using System;
using System.Windows.Forms;
using model.video;

namespace gui
{
    public partial class PlayerNavigationPanel : UserControl
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        public event Action NextFile
        {
            add
            {
                playerControlPanel1.NextFile += value;
            }
            remove
            {
                playerControlPanel1.NextFile -= value;
            }
        }
        
        public VideoFilePlayer VideoPlayer
        {
            get
            {
                return player;
            }
            set
            {
                player?.Stop();
                player = value;
                UpdateSpeedText();
                if (value != null) 
                    playerControlPanel1.Reset();
                else
                    playerControlPanel1.Enabled = false;
            }
        }

        public bool VisibleTrackBar
        {
            get
            {
                return trackBar1.Visible;
            }
            set
            {
                trackBar1.Visible = value;
            }
        }

        public event Action<string> StatusText;
        public event Action<double> ProgressChange;
        private VideoFilePlayer player;

        private DateTime lastScrollTime;
        private double lastScrollVal;

        public PlayerNavigationPanel()
        {
            InitializeComponent();
            lastScrollTime = DateTime.MinValue;
            lastScrollVal = -1;

            trackBar1.SetRange(0, 1000);
            playerControlPanel1.Play += PlayerControlPanel1_Play;
            playerControlPanel1.Pause += PlayerControlPanel1_Pause;
            playerControlPanel1.Slow += PlayerControlPanel1_Slow;
            playerControlPanel1.Fast += PlayerControlPanel1_Fast;
            playerControlPanel1.SoundEvent += PlayerControlPanel1_Sound;
        }

        private void UpdateSpeedText()
        {
            if (player == null)
                StatusText?.Invoke("");
            else
                StatusText?.Invoke("Скорость: " + player.Speed);
        }

        private void PlayerControlPanel1_Sound(bool sound)
        {
            if (player == null) return;

            player.Sound = sound;
        }

        private void PlayerControlPanel1_Slow()
        {
            if (player == null) return;

            player.Slow();
            UpdateSpeedText();
        }

        private void PlayerControlPanel1_Fast()
        {
            if (player == null) return;

            player.Fast();
            UpdateSpeedText();
        }

        private void PlayerControlPanel1_Pause(bool pause)
        {
            if (player == null) return;

            player.Pause = pause;
            UpdateSpeedText();
        }

        private void PlayerControlPanel1_Play(bool run)
        {
            if (player == null) return;

            if (run)
            {
                Log.Info("{0}: start play file", this);
                player.Start();
                timerPlayBack.Start();
            }
            else
            {
                player.Stop();
                timerPlayBack.Stop();
                playerControlPanel1.Reset();
            }
            UpdateSpeedText();
        }

        private void timerPlayBack_Tick(object sender, EventArgs e)
        {
            if (player == null) return;

            if ((DateTime.Now - lastScrollTime).TotalSeconds < 1) return;

            if (lastScrollVal > 0)
            {
                player.SetPlayPos(lastScrollVal);
                lastScrollVal = -1;
                lastScrollTime = DateTime.Now;
                UpdateSpeedText();
            }
            else
            {
                var max = trackBar1.Maximum;
                int pos = Convert.ToInt32(player.GetPlayPos() * max);
                if (pos <= max)
                {
                    trackBar1.Value = pos;
                    ProgressChange?.Invoke((double) trackBar1.Value / trackBar1.Maximum);

                    if (pos == max)
                        playerControlPanel1.DoNextFile();
                }
            }
        }

        internal void Start()
        {
            playerControlPanel1.DoPlayClick();
        }

        internal void Stop()
        {
            PlayerControlPanel1_Play(false);
        }

        public void ScrollToPos(double val)
        {
            lastScrollVal = (float)val;
            lastScrollTime = DateTime.Now;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double v = trackBar1.Value;
            double m = trackBar1.Maximum;
            ScrollToPos(v / m);
        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            var dX = (double)e.X / (double)trackBar1.Width;
            trackBar1.Value = Convert.ToInt32(dX * (trackBar1.Maximum - trackBar1.Minimum));
            ProgressChange?.Invoke(dX);
            ScrollToPos(dX);
        }

        public override string ToString()
        {
            return "player navigation";
        }
    }
}
