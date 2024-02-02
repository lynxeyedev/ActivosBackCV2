using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivosAPI.Infraestructura.Database.Entity.MySQL
{
    [Table("Clients")]
    public class ClientsEntity
    {
        [Key]
        public int id { get; set; }
        public string? CodCliente { get; set; }
        public string? NIF { get; set; }
        public int? NOSE1 { get; set; }
        public string? NOSE2 { get; set; }
        public string? NOSE3 { get; set; }
        public string? NOMBRE1 { get; set; }
        public string? NOMBRE2 { get; set; }
        public string? EMAIL { get; set; }
        public string? TELEFONO { get; set; }
        public string? DIRECCION { get; set; }
        public string? CP { get; set; }
        public string? CIUDAD { get; set; }
        public string? CIUDAD2 { get; set; }
        public int? NOSE4 { get; set; }
        public string? NOSE5 { get; set; }
        public DateTime FECHA1 { get; set; } = DateTime.Now;
        public DateTime FECHA2 { get; set; } = DateTime.Now;
        public int? NOSE6 { get; set; }
        public int? NOSE7 { get; set; }
        public int? NOSE8 { get; set; }
    }
}
