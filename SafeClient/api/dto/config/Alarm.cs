namespace SafeServer.dto.config
{
    public class Alarm
    {
        public long timeout { get; set; }
        /// <summary>
        /// количество циклов
        /// </summary>
        public long count { get; set; }

        /// <summary>
        /// длительность сирены
        /// </summary>
        public long delay { get; set; }

        /// <summary>
        /// затишье между сиренами
        /// </summary>
        public long period { get; set; }
    }
}