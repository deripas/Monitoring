using System.ComponentModel.DataAnnotations.Schema;

namespace SafeServer.dto
{
    [Table("nvr")]
    public class Nvr
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("ip")]
        public string Ip { get; set; }

        [Column("port")]
        public ushort Port { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("password")]
        public string Password { get; set; }
    }
}
