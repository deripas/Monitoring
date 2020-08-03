using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace gui.component
{
    public class SelectedTrackBar : TrackBar
    {
        const int TBS_ENABLESELRANGE = 0x00000020; 

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= TBS_ENABLESELRANGE;
                return cp;
            }
        }

        public void Select(int from, int to)
        {
            SendMessage(Handle, 1024 + 11, 0, from);
            SendMessage(Handle, 1024 + 12, 0, to);
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

    }
}
