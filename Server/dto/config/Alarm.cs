namespace SafeServer.dto.config
{
    public class Alarm
    {
        public long timeout { get; set; }
        /// <summary>
        /// количество циклов
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// длительность сирены
        /// </summary>
        public int delay { get; set; }

        /// <summary>
        /// затишье между сиренами
        /// </summary>
        public int period { get; set; }
    }
}