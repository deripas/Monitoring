using System;
using System.Drawing;
using System.Windows.Forms;

namespace gui
{
    public partial class CanvasPanel : UserControl
    {
        private static readonly int borderSize = 10;
        private double _ratio = 0.75D;

        public double Ratio
        {
            get
            {
                return _ratio;
            }
            set
            {
                _ratio = value;
                DoResize();
            }
        }

        public bool Selected { get; set; }

        public PictureBox Canvas => pictureBox1;

        private Size ViewSize
        {
            get
            {
                var ratio = _ratio;
                var w = Math.Min(this.Width, (int)Math.Round(this.Height / ratio));
                var h = (int)Math.Round(w * ratio);
                var b = Selected ? borderSize : 0;
                return new Size(w - b, h - b);
            }
        }

        public CanvasPanel()
        {
            _ratio = 0.75D;
            Selected = false;
            InitializeComponent();
        }

        private void DoResize()
        {
            var size = ViewSize;
            var loc = new Point((this.Width - size.Width) / 2, (this.Height - size.Height) / 2);
            pictureBox1?.SetBounds(loc.X, loc.Y, size.Width, size.Height);
        }

        private void CanvasPanel_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
    }
}
