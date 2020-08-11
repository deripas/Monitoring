using api.dto;
using model.device;
using service;
using System;
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
                SensorView view = createView(dev);
                if (view == null) continue;

                flowLayoutPanel1.Controls.Add(view.GetControl());
                view.Set(dev);
            }

            CorrectSize();
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
                default:
                    return null;
            }
        }

        private void CorrectSize()
        {
            int h = 100;
            foreach (Control c in flowLayoutPanel1.Controls)
                h += c.Height;
            panel1.Height = h;
        }
    }
}
