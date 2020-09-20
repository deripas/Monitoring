using System;
using System.Windows.Forms;

namespace gui
{
    public partial class PlayerControlPanel : UserControl
    {
        public event Action<bool> Play;
        public event Action<bool> Pause;
        public event Action<bool> SoundEvent;
        public event Action Slow;
        public event Action Fast;
        public event Action NextFile;

        public bool Sound
        {
            get
            {
                return checkBoxSound.Checked;
            }
            set
            {
                checkBoxSound.Checked = value;
            }
        }

        public PlayerControlPanel()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            Enabled = true;
            UpdateButtons(false);
        }

        private void UpdateButtons(bool running)
        {
            checkBoxPause.Checked = false;
            buttonPlay.Enabled = !running && Play != null;
            buttonStop.Enabled = running && Play != null;
            checkBoxPause.Enabled = running && Pause != null;
            buttonFast.Enabled = running && Fast != null;
            buttonSlow.Enabled = running && Slow != null;
            buttonNext.Enabled = running && NextFile != null;
            checkBoxSound.Enabled = running && SoundEvent != null;
        }

        private String SoundSymbol(bool sound)
        {
            return sound ? "🔊" : "🔈";
        }

        public void DoPlayClick()
        {
            buttonPlay_Click(null, null);
        }

        public void DoNextFile()
        {
            buttonNext_Click(null, null);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            UpdateButtons(true);
            Play?.Invoke(true);
            if (checkBoxSound.Checked)
                checkBoxSound_CheckedChanged(null, null);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            UpdateButtons(false);
            Play?.Invoke(false);
        }

        private void buttonSlow_Click(object sender, EventArgs e)
        {
            Slow?.Invoke();
        }

        private void buttonFast_Click(object sender, EventArgs e)
        {
            Fast?.Invoke();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            NextFile?.Invoke();
        }

        private void checkBoxPause_CheckedChanged(object sender, EventArgs e)
        {
            Pause?.Invoke(checkBoxPause.Checked);
        }

        private void checkBoxSound_CheckedChanged(object sender, EventArgs e)
        {
            var lable = SoundSymbol(checkBoxSound.Checked);
            checkBoxSound.Text = lable;
            SoundEvent?.Invoke(checkBoxSound.Checked);
        }
    }
}
