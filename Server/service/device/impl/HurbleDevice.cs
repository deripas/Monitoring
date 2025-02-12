﻿using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using SafeServer.dto;

namespace SafeServer.service.device
{
    public class HurbleDevice : AlarmSensorDevice
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private readonly IObservable<bool> encoder;
        private readonly IObservable<bool> remote;
        private readonly BehaviorSubject<int> mode = new BehaviorSubject<int>(0);

        public HurbleDevice(Device device) : base(device)
        {
            remote = GetBool41(device.Config.remote)
                .ToBool()
                .Select(b => !b);

            encoder = new BehaviorSubject<bool>(false);
        }

        public override void Init()
        {
            if (Config.encoder != null)
            {
                _(GetBool41(Config.encoder)
                    .ToThresholdRate(Config.counter.threshold)
                    .Subscribe((IObserver<bool>)encoder));
            }
            
            var power = mode.CombineLatest(remote, encoder, AgregatePower);

            Sensor(GetBool41(Config.sensor)
                .ToBool()
                .CombineLatest(power, (b1, b2) => b1 && b2)
                .Select(v => DeviceStatus.Value(Id, v)));
            base.Init();
        }

        protected bool AgregatePower(int mode, bool remote, bool encoder)
        {
            return mode switch
            {
                0 => false,
                1 => remote,
                2 => encoder && remote,
                _ => false,
            };
        }

        protected DeviceStatus AgregateStatus(DeviceStatus status, int mode, bool remote, bool encoder)
        {
            bool power = AgregatePower(mode, remote, encoder);
            
            Control control = Control.NULL;
            if (power) control |= Control.POWER;
            if (remote) control |= Control.REMOTE;
            if (encoder) control |= Control.ENCODER;
            if (mode==0) control |= Control.OFF;
            if (mode==1) control |= Control.ON;
            if (mode==2) control |= Control.AUTO;
            status.value = (int)control;
            return status;
        }

        public override IObservable<DeviceStatus> Status()
        {
            return base.Status()
                .CombineLatest(mode, remote, encoder, AgregateStatus);
        }

        public void PowerOn()
        {
            if (IsEnable())
            {
                Log.Info("{}({}) hurble ON", Name, Id);
                mode.OnNext(1);
            }
        }

        public void PowerOff()
        {
            if (IsEnable())
            {
                Log.Info("{}({}) hurble OFF", Name, Id);
                mode.OnNext(0);
            }
        }

        public void PowerAuto()
        {
            if (IsEnable())
            {
                Log.Info("{}({}) hurble AUTO", Name, Id);
                mode.OnNext(2);
            }
        }

        public override void Update(Config cfg)
        {
            if (cfg.counter != null)
            {
                Config.counter = cfg.counter;
                Log.Info("{}({}) cange threshold {}", Name, Id, cfg.counter.threshold);
            }
            base.Update(cfg);
        }

        public override string RenderStatusValue(DeviceStatus status)
        {
            Control control = (Control)status.value;
            if (!control.HasFlag(Control.POWER))
                return "выкл.";

            return (status.alarm <= 0) ? "норма" : "тревога";
        }
    }

    [Flags]
    public enum Control
    {
        NULL = 0,
        POWER = 1,
        REMOTE = 2,
        ENCODER = 4,
        ON = 8,
        OFF = 16,
        AUTO = 32,
    }
}