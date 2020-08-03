using System;
using System.Windows.Forms;

namespace gui
{
    public partial class PlayerControlPanel : UserControl
    {
        public event Action<bool> Play;
        public event Action<bool> Pause;
        public event Action Slow;
        public event Action Fast;

        public PlayerControlPanel()
        {
            InitializeComponent();
        }

        public void Reset()
        {
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
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            UpdateButtons(true);
            Play?.Invoke(true);
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

        }

        private void checkBoxPause_CheckedChanged(object sender, EventArgs e)
        {
            Pause?.Invoke(checkBoxPause.Checked);
        }
    }
}
