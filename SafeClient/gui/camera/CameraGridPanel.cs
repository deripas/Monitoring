using service;
using System.Collections.Generic;
using System.Windows.Forms;

namespace gui
{
    public partial class CameraGridPanel : UserControl
    {
        private readonly List<CameraViewPanel> views = new List<CameraViewPanel>();
        private int cols;
        private int rows;
        private CameraViewPanel select;

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
            if (cols <= 1 && rows <= 1) return;

            if (select == null)
            {
                select = owner;
                Clear(views.FindAll(v => v != owner));
                Table(1, 1);
                table.Controls.Add(owner);
            }
            else
            {
                // restore
                Grid(cols, rows);
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

        public void Grid(int cols, int rows)
        {
            this.cols = cols;
            this.rows = rows;
            select = null;

            Clear(views);
            Table(cols, rows);

            var list = DI.Instance.CameraService.CameraList;
            for (var i = 0; i < cols * rows && i < list.Count; i++)
            {
                var cam = list[i];
                var viewControl = views[i];
                table.Controls.Add(viewControl);

                viewControl.Ratio = cam.Ratio;
                viewControl.StartPlay(cam);
            }
        }

        private static void Clear(ICollection<CameraViewPanel> views)
        {
            foreach (var view in views)
                view.StopPlay();
        }
    }
}
