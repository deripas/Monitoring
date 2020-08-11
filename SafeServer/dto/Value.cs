using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafeServer.dto
{
    [NotMapped]
    public class Value
    {
        public DateTime time { get; set; }

        public int device { get; set; }

        public double val { get; set; }
    }
}
