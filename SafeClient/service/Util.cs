using System;

namespace service
{
    public static class Util
    {
        public static String ToRus(this bool value)
        {
            return value ? "Да" : "Нет";
        }
    }
}
