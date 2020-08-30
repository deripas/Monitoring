using System;
using System.Drawing;
using System.Windows.Forms;

namespace gui
{
    public partial class CanvasPanel : UserControl
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private static readonly int borderSize = 10;
        private double _ratio = 0.75D;
        private bool _select;
        private RectangleF zoom;

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

        public bool Selected
        {
            get
            {
                return _select;
            }
            set
            {
                _select = value;
                DoResize();
            }
        }

        public PictureBox Canvas => canvas;

        private Size ViewSize
        {
            get
            {
                var ratio = _ratio;
                var w = Math.Min(this.Width, (int)Math.Round(this.Height / ratio));
                var h = (int)Math.Round(w * ratio);
                var b = _select ? borderSize : 0;
                return new Size(w - b, h - b);
            }
        }

        public CanvasPanel()
        {
            _ratio = 0.75D;
            Selected = false;
            zoom = new RectangleF(0f, 0f, 1f, 1f);
            InitializeComponent();
        }

        private void DoResize()
        {
            var size = ViewSize;
            var loc = new Point((this.Width - size.Width) / 2, (this.Height - size.Height) / 2);
            panel?.SetBounds(loc.X, loc.Y, size.Width, size.Height);
            canvas?.SetBounds(0, 0, size.Width, size.Height);
        }

        private void CanvasPanel_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
    }
}
