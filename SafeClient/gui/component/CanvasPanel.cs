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
        private bool _zoom;
        private double scale;
        private PointF dxy;
        private Point xy;

        public double Ratio
        {
            get
            {
                return _ratio;
            }
            set
            {
                _ratio = value;
                dxy = new PointF(0f, 0f);
                scale = 1;
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
            scale = 1d;
            xy = Point.Empty;
            dxy = new PointF(0f, 0f);
            InitializeComponent();
        }

        private void DoResize()
        {
            var size = ViewSize;
            var loc = new Point((this.Width - size.Width) / 2, (this.Height - size.Height) / 2);
            panel?.SetBounds(loc.X, loc.Y, size.Width, size.Height);
            //canvas?.SetBounds(0, 0, size.Width, size.Height);
            canvas?.SetBounds((int)(dxy.X * size.Width), (int)(dxy.Y * size.Height), (int)(scale * size.Width), (int)(scale * size.Height));
        }

        private void CanvasPanel_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            var sizeOrig = ViewSize;
            var viewScaleOld = new Rectangle((int)(dxy.X * sizeOrig.Width), (int)(dxy.Y * sizeOrig.Height), (int)(scale * sizeOrig.Width), (int)(scale * sizeOrig.Height));
            
            scale += e.Delta * 0.001f;
            if (scale < 1) scale = 1;

            var viewScale = new Rectangle((int)(dxy.X * sizeOrig.Width), (int)(dxy.Y * sizeOrig.Height), (int)(scale * sizeOrig.Width), (int)(scale * sizeOrig.Height));

            // scale by center
            var p0 = new Point((sizeOrig.Width - viewScale.Width) / 2, (sizeOrig.Height - viewScale.Height) / 2);

            var dx = viewScaleOld.X + (viewScaleOld.Width - viewScale.Width) / 2;
            var dy = viewScaleOld.Y + (viewScaleOld.Height - viewScale.Height) / 2;
            dxy.X = (float)(dx) / sizeOrig.Width;
            dxy.Y = (float)(dy) / sizeOrig.Height;
            //canvas?.SetBounds((int)(dxy.X * sizeOrig.Width), (int)(dxy.Y * sizeOrig.Height), viewScale.Width, viewScale.Height);
            correctSetBounds();
        }

        private void correctSetBounds()
        {
            var size = ViewSize;
            var dx = (int)(dxy.X * size.Width);
            var dy = (int)(dxy.Y * size.Height);
            var w = (int)(scale * size.Width);
            var h = (int)(scale * size.Height);

            if (dx > 0) dx = 0;
            if (dy > 0) dy = 0;
            if (w + dx < size.Width) dx = size.Width - w;
            if (h + dy < size.Height) dy = size.Height - h;

            dxy.X = (float)(dx) / size.Width;
            dxy.Y = (float)(dy) / size.Height;
            canvas?.SetBounds(dx, dy, w, h);
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (xy.IsEmpty && e.Button == MouseButtons.Left)
            {
                xy = e.Location;
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!xy.IsEmpty && e.Button == MouseButtons.Left)
            {
                xy = Point.Empty;
                correctSetBounds();
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!xy.IsEmpty && e.Button == MouseButtons.Left)
            {
                var dx = e.Location.X - xy.X;
                var dy = e.Location.Y - xy.Y;
                var size = ViewSize;
                dxy.X = (dxy.X * size.Width + dx) / size.Width;
                dxy.Y = (dxy.Y * size.Height + dy) / size.Height;
                canvas?.SetBounds((int)(dxy.X * size.Width), (int)(dxy.Y * size.Height), (int)(scale * size.Width), (int)(scale * size.Height));
            }
        }
    }
}
