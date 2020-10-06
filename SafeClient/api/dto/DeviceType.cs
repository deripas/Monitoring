namespace api.dto
{
    public enum DeviceType
    {
        unknown,
        temperature,
        pressure,
        smoke,
        water,
        vibration,
        vibration2,
        rollet,
        hurble,
    }

    static public class DeviceTypeUtil
    {
        public static bool IsSensor(this DeviceType type)
        {
            switch (type)
            {
                case DeviceType.pressure:
                case DeviceType.temperature:
                case DeviceType.water:
                case DeviceType.smoke:
                case DeviceType.vibration:
                case DeviceType.vibration2:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsControll(this DeviceType type)
        {
            switch (type)
            {
                case DeviceType.rollet:
                case DeviceType.hurble:
                    return true;
                default:
                    return false;
            }
        }
    }
}
