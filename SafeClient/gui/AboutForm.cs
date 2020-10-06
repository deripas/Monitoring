using Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gui
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            Icon = Resources.AppIcon2;
            try
            {
                pictureBox1.Image = Image.FromFile("logo.png");
            }
            catch (Exception e)
            {
                pictureBox1.Image = Resources.lmz;
            }
        }
    }
}
