using System.ComponentModel.DataAnnotations.Schema;

namespace SafeServer.dto
{
    [Table("device")]
    public class Device
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("enable")]
        public bool Enable { get; set; }

        [Column("removed")]
        public bool Removed { get; set; }

        [Column("camera")]
        public int? Camera { get; set; }

        [Column("type")]
        public string Type { get; set; }
        
        [Column("version")]
        public long Version { get; set; }
        
        [Column("config", TypeName = "jsonb")]
        public Config Config  { get; set; }

        [Column("stand_id")]
        public string Stand { get; set; }
    }
}
