using api.dto;
using model.device;
using service;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace gui
{
    public partial class SensorPanel : UserControl
    {
        public SensorPanel()
        {
            InitializeComponent();
        }

        private void SensorPanel_Load(object sender, EventArgs e)
        {
            if (DI.Instance.DeviceService == null) return;

            foreach (DeviceController dev in DI.Instance.DeviceService.DeviceList)
            {
                var view = createView(dev);
                if (view == null) continue;

                dev.View = view;
            }
        }

        private SensorView createView(DeviceController dev)
        {
            switch (dev.Type)
            {
                case DeviceType.temperature:
                        return new TemperatureSensor();
                case DeviceType.pressure:
                        return new PressureSensor();
                case DeviceType.smoke:
                        return new SmokeSensor();
                case DeviceType.water:
                        return new LeakSensor();
                case DeviceType.vibration:
                        return new VibrationSensor();
                case DeviceType.vibration2:
                        return new VibrationSensor();
                default:
                    return null;
            }
        }

        internal void Set(List<int> deviceList)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach(var id in deviceList)
            {
                var dev = DI.Instance.DeviceService[id];
                var control = dev.View?.GetControl();
                flowLayoutPanel1.Controls.Add(control);
                Application.DoEvents();
            }
            CorrectSize();
        }

        private void CorrectSize()
        {
            int h = 50;
            foreach (Control c in flowLayoutPanel1.Controls)
                h += (c.Height + 6);
            panel1.Height = h;
        }
    }
}
