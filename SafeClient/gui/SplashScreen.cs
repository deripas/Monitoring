using System;
using System.Windows.Forms;

namespace gui
{
    public partial class SplashScreen : Form
    {
        private readonly Timer timer = new Timer();
        private MainForm mainForm;
        
        public SplashScreen()
        {
            InitializeComponent();
            timer.Enabled = false;
            timer.Interval = 1;
            timer.Tick += Tmr_Tick;
        }
        
        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            mainForm = new MainForm();
            timer.Start();
        }

        private void Tmr_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Hide();
            mainForm?.Show();
        }
    }
}