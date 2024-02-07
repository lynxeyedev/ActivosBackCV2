using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivosAPI.Infraestructura.Database.Entity.SQL
{
    [Table("Contacts")]
    public class ContactoSQLEntity
    {
        [Key]
        public int? idContact { get; set; }
        public int? idCliente { get; set; }
        public string? telf1 { get; set; }
        public string? telf2 { get; set; }
        public string? contacEmail { get; set; }
        public int? campo2 { get; set; }
        public int? campo5 { get; set; }
        public int? idContactMySql { get; set; }
    }
}
