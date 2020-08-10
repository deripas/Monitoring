using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SafeServer.dto
{
    [Table("camera")]
    public class Camera
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("rate")]
        public double Rate { get; set; }

        [Column("ratio")]
        public double Ratio { get; set; }

        [Column("dvr")]
        public int nvr { get; set; }

        [Column("channel")]
        public int Channel { get; set; }

        [Column("enable")]
        public bool Enable { get; set; }
    }
}
