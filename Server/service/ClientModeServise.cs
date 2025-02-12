﻿using Microsoft.Extensions.Caching.Memory;
using SafeServer.dto;
using SafeServer.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Server.service
{
    public enum StandMode
    {
        Mode1,
        Mode2,
        Mode3,
        Close
    }

    public class ClientModeServise
    {
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        private HashSet<Guid> gradOry;
        private DeviceService deviceService;

        public ClientModeServise(DeviceService deviceService)
        {
            gradOry = new HashSet<Guid>();
            this.deviceService = deviceService;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        internal void ChangeMode(Guid id, string stand, string mode)
        {
            Log.Info("client {0}({1}) change mode to {2}", id, stand, mode);
            Enum.TryParse(mode, out StandMode standMode);

            using var db = new DatabaseService();
            var standTP = db.Device
                .Where(dev => dev.Removed == false
                    && dev.Stand.Equals(stand)
                    && (dev.Type.Equals("temperature") || dev.Type.Equals("pressure")));
            var oryP = db.Device
                .Where(dev => dev.Removed == false
                    && dev.Stand.Equals("ory") 
                    && dev.Type.Equals("pressure"));


            switch (standMode)
            {
                case StandMode.Mode1:
                    {
                        gradOry.Remove(id);
                        Enable(standTP, true);
                        break;
                    }
                case StandMode.Mode2:
                    {
                        gradOry.Add(id);
                        Enable(standTP, true);
                        break;
                    }
                case StandMode.Mode3:
                    {
                        gradOry.Remove(id);
                        Enable(standTP, false);
                        break;
                    }
                case StandMode.Close:
                    {
                        gradOry.Remove(id);
                        break;
                    }
            }
            Enable(oryP, gradOry.Count > 0);
            db.SaveChanges();
        }

        private void Enable(IQueryable<Device> list, bool enable)
        {
            foreach (var dev in list)
            {
                if (dev.Enable == enable) continue;

                var device = deviceService[dev.Id];

                dev.Enable = enable;
                dev.Version++;

                device.Enable = dev.Enable;
                device.Version = dev.Version;
                Log.Info("{}({}) enable status {} (ver: {})", dev.Name, dev.Id, dev.Enable, dev.Version);
            }
        }

        internal void Dispose()
        {
            gradOry.Clear();
        }
    }
}
