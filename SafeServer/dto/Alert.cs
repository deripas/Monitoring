using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafeServer.dto
{
    [Table("alert")]
    public class Alert
    {
        [Column("id")]
        public long id { get; set; }

        [Column("device")]
        public int device { get; set; }

        [Column("time")]
        public DateTime time { get; set; }

        [Column("value")]
        public double value { get; set; }

        [Column("processed")]
        public bool processed { get; set; }
    }
}
