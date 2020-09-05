namespace SafeServer.dto.config
{
    public class Calibr
    {
        public double porogMax { get; set; }
        public double porogMin { get; set; }
        public double min { get; set; }
        public double max { get; set; }

        public override string ToString()
        {
            return $"{nameof(porogMax)}: {porogMax}, {nameof(porogMin)}: {porogMin}, {nameof(min)}: {min}, {nameof(max)}: {max}";
        }
    }
}
