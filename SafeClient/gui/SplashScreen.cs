using System;
using System.Windows.Forms;

namespace gui
{
    public partial class SplashScreen : Form
    {
        private readonly Timer timerHide = new Timer();
        private readonly Timer timerShow = new Timer();
        private MainForm mainForm;
        
        public SplashScreen()
        {
            InitializeComponent();
            timerHide.Enabled = false;
            timerHide.Interval = 1000;
            timerHide.Tick += Tmr_Tick;

            timerShow.Enabled = false;
            timerShow.Interval = 1;
            timerShow.Tick += Tmr_Tick2;
        }

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            try
            {
                mainForm = new MainForm();
                timerShow.Start();
                timerHide.Start();
            }
            catch (Exception ex)
            {
                Hide();
                MessageBox.Show(ex.Message, "Ошибка");
                Application.Exit();
            }
        }

        private void Tmr_Tick(object sender, EventArgs e)
        {
            timerHide.Stop();
            timerHide.Dispose();
            Hide();
        }

        private void Tmr_Tick2(object sender, EventArgs e)
        {
            timerShow.Stop();
            timerShow.Dispose();
            mainForm?.Show();
        }
    }
}