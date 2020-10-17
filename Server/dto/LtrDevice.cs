using Server.dto.config;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server.dto
{
    [Table("ltr_device")]
    public class LtrDevice
    {
        [Column("sn")]
        public string Sn { get; set; }

        [Column("num")]
        public int Num { get; set; }

        [Column("ch")]
        public int Ch { get; set; }

        [Column("device")]
        public int Device { get; set; }

        [Column("field")]
        public string Field { get; set; }

        [Column("cfg", TypeName = "jsonb")]
        public Cfg Cfg { get; set; }
    }
}
