using service;
using System.Collections.Generic;
using System.Windows.Forms;

namespace gui
{
    public partial class CameraGridPanel : UserControl
    {
        private readonly List<CameraViewPanel> views = new List<CameraViewPanel>();

        public CameraGridPanel()
        {
            InitializeComponent();
            for(int i = 0; i < 36; i++)
                views.Add(new CameraViewPanel { Dock = DockStyle.Fill });
            
        }

        public void Grid(int cols, int rows)
        {
            Clear(views);

            table.Controls.Clear();
            table.ColumnStyles.Clear();
            table.RowStyles.Clear();
            table.ColumnCount = cols;
            table.RowCount = rows;

            for (var i = 0; i < cols; i++)
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            for (var i = 0; i < rows; i++)
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));


            var list = DI.Instance.CameraService.CameraList;
            for (var i = 0; i < cols * rows && i < list.Count; i++)
            {
                var viewControl = views[i];
                table.Controls.Add(viewControl);
                views.Add(viewControl);

                viewControl.Ratio = 9D / 16D;
                viewControl.StartPlay(list[i]);
            }
        }

        private static void Clear(ICollection<CameraViewPanel> views)
        {
            foreach (var view in views)
                view.StopPlay();
        }
    }
}
