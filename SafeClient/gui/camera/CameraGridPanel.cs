using api.dto;
using service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui
{
    public partial class CameraGridPanel : UserControl
    {
        private double _ratio = 0.5625D;
        private readonly List<CameraViewPanel> views = new List<CameraViewPanel>();
        private CameraGrid grid;
        private CameraViewPanel select;

        private Size TableSize
        {
            get
            {
                var ratio = _ratio;
                var w = Math.Min(this.Width, (int)Math.Round(this.Height / ratio));
                var h = (int)Math.Round(w * ratio);
                var b = 0;
                return new Size(w - b, h - b);
            }
        }

        public CameraGridPanel()
        {
            InitializeComponent();
            for (int i = 0; i < 36; i++)
            {
                var vp = new CameraViewPanel { Dock = DockStyle.Fill };
                views.Add(vp);

                vp.DoubleClick += Vp_DoubleClick;
            }
        }

        private void Vp_DoubleClick(CameraViewPanel owner)
        {
            if (grid.cols <= 1 && grid.rows <= 1) return;

            if (select == null)
            {
                select = owner;
                Clear(views.FindAll(v => v != owner));
                Table(1, 1);
                owner.MainStream = true;
                table.Controls.Add(owner);
            }
            else
            {
                // restore
                Grid(grid);
            }
        }

        private void Table(int cols, int rows)
        {
            table.Controls.Clear();
            table.ColumnStyles.Clear();
            table.RowStyles.Clear();
            table.ColumnCount = cols;
            table.RowCount = rows;

            for (var i = 0; i < cols; i++)
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            for (var i = 0; i < rows; i++)
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        }

        public void Grid(CameraGrid grid)
        {
            this.grid = grid;
            select = null;

            Clear(views);
            Table(grid.cols, grid.rows);

            var list = grid.cams;
            for (var i = 0; i < grid.cols * grid.rows && i < list.Count; i++)
            {
                var viewControl = views[i];
                table.Controls.Add(viewControl);

                var camId = list[i];
                if (camId > 0)
                {
                    var cam = DI.Instance.CameraService[camId];
                    viewControl.Ratio = cam.Ratio;
                    viewControl.StartPlay(cam);
                }
                else
                {
                    viewControl.Ratio = _ratio;
                    viewControl.Empty();
                }
            }
        }

        private static void Clear(ICollection<CameraViewPanel> views)
        {
            foreach (var view in views)
                view.StopPlay();
        }

        private void CameraGridPanel_Resize(object sender, System.EventArgs e)
        {
            DoResize();
        }

        private void DoResize()
        {
            var size = TableSize;
            var loc = new Point((this.Width - size.Width) / 2, (this.Height - size.Height) / 2);
            table?.SetBounds(0, 0, size.Width, size.Height);
        }
    }
}
