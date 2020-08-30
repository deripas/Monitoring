﻿using System;
using System.Windows.Forms;
using model.device;
using api.dto;
using Properties;

namespace gui
{
    public partial class RolletControl : UserControl, SensorView
    {
        private DeviceController device;
        private volatile bool up;
        private volatile bool dw;

        public RolletControl()
        {
            InitializeComponent();
        }

        public Control GetControl()
        {
            return this;
        }

        public void Set(DeviceController dev)
        {
            device = dev;
            led.Image = dev.Enable ? Resources.led_green : Resources.led_gray;
        }

        public void Update(SensorStatus status)
        {
            var change = (up != status.up) || (dw != status.dw);
            dw = status.dw;
            up = status.up;
            if (!change) return;
            
            if (dw == up)
            {
                pictureIcon.Image = Resources.rollet_move;
                led.Image = Resources.led_red;
                buttonDown.Enabled = true;
                buttonUp.Enabled = true;
            }
            else
            {
                led.Image = Resources.led_green;
                if (dw)
                {
                    pictureIcon.Image = Resources.rollet_dw;
                    buttonDown.Enabled = false;
                    buttonUp.Enabled = true;
                }
                else
                {
                    pictureIcon.Image = Resources.rollet_up;
                    buttonDown.Enabled = true;
                    buttonUp.Enabled = false;
                }
            }
        }


        private void buttonDown_Click(object sender, EventArgs e)
        {
            device?.RolletDown();
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            device?.RolletUp();
        }

        private void led_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            device?.RolletStop();
        }
    }
}
