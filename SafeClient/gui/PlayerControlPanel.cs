using System;
using System.Windows.Forms;

namespace gui
{
    public partial class PlayerControlPanel : UserControl
    {
        public event Action<bool> Play;
        public event Action<bool> Pause;
        public event Action<int> Speed;
        private int speedValue = 0;

        public PlayerControlPanel()
        {
            InitializeComponent();
        }

        public void Ready()
        {
            UpdateButtons(false);
        }

        private void UpdateButtons(bool running)
        {
            checkBoxPause.Checked = false;
            buttonPlay.Enabled = !running && Play != null;
            buttonStop.Enabled = running && Play != null;
            checkBoxPause.Enabled = running && Pause != null;
            buttonFast.Enabled = running && Speed != null;
            buttonSlow.Enabled = running && Speed != null;
            speedValue = 0;
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
            speedValue = Math.Max(speedValue - 1, -4);
            Speed?.Invoke(speedValue);
        }

        private void buttonFast_Click(object sender, EventArgs e)
        {
            speedValue = Math.Min(speedValue + 1, 4);
            Speed?.Invoke(speedValue);
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
