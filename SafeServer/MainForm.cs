using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Windows.Forms;
using System.Windows.Forms;

namespace SafeServer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void InitLogger()
        {
            RichTextBoxTarget target = new RichTextBoxTarget();
            target.Layout = "${date:format=HH\\:MM\\:ss} [${threadid}] ${level:uppercase=true} ${logger} - ${message}${exception:format=ToString}";
            target.ControlName = richTextBox1.Name;
            target.FormName = this.Name;
            target.UseDefaultRowColoringRules = true;
            SimpleConfigurator.ConfigureForTargetLogging(target, LogLevel.Trace);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            InitLogger();
        }
    }
}
