using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SafeServer.dto
{
    [Table("device")]
    public class Device
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("enable")]
        public bool Enable { get; set; }

        [Column("camera")]
        public int Camera { get; set; }

        [Column("type")]
        public string Type { get; set; }
    }
}
