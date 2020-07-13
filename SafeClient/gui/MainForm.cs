using System.Windows.Forms;
using service;

namespace SafeClient.gui
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            DI.Instance.Init();
            InitializeComponent();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DI.Instance.Dispose();
            Application.Exit();
        }
    }
}