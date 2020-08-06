using System.Windows.Forms;
using service;

namespace gui
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            DI.Instance.Init();
            InitializeComponent();
            toolStripSplitButton1.SelectedIndex = 0;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CameraPtzForm.Instance.Dispose();
            VideoViewForm.Instance.Dispose();
            AlertViewForm.Instance.Dispose();
            VideoExportForm.Instance.Dispose();
            DI.Instance.Dispose();
            Application.Exit();
        }

        private void toolStripSplitButton1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var index = toolStripSplitButton1.SelectedIndex;
            var val = index + 1;
            grid.Grid(val, val);
        }

        private void toolStripButton1_Click(object sender, System.EventArgs e)
        {
            VideoViewForm.Instance.Start();
        }

        private void toolStripButton2_Click(object sender, System.EventArgs e)
        {
            AlertViewForm.Instance.Start();
        }
    }
}