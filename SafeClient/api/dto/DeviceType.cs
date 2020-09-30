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
