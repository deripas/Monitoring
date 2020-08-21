using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SafeServer.dto
{
    [Table("ltr")]
    public class LTR
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("sn")]
        public string Sn { get; set; }

        [Column("num")]
        public int Num { get; set; }

        [Column("type")]
        public string Type { get; set; }
    }
}
