using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using service;
using model.device;
using api.dto;

namespace gui
{
    public partial class ControlPanel : UserControl
    {
        public ControlPanel()
        {
            InitializeComponent();
        }

        private void ControlPanel_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            if (DI.Instance.DeviceService == null) return;

            foreach (DeviceController dev in DI.Instance.DeviceService.DeviceList)
            {
                SensorView view = createView(dev);
                if (view == null) continue;
                
                dev.View = view;
            }
        }

        private SensorView createView(DeviceController dev)
        {
            switch (dev.Type)
            {
                case DeviceType.rollet:
                    return new RolletControl();
                case DeviceType.hurble:
                    return new ClassicHurbleControl();
                default:
                    return null;
            }
        }

        internal void Set(List<int> controlList)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var id in controlList)
            {
                var dev = DI.Instance.DeviceService[id];
                var control = dev.View?.GetControl();
                flowLayoutPanel1.Controls.Add(control);
            }
        }
    }
}
