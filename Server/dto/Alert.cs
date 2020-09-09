using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafeServer.dto
{
    [Table("alert")]
    public class Alert
    {
        public static Alert NULL = new Alert()
        {
            id = -1,
            device = -1,
            time = DateTime.MinValue,
            value = 0,
            processed = false
        };

        [Column("id")]
        public long id { get; set; }

        [Column("device")]
        public long device { get; set; }

        [Column("time")]
        public DateTime time { get; set; }

        [Column("value")]
        public double value { get; set; }

        [Column("processed")]
        public bool processed { get; set; }

    }
}
