using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivosAPI.Infraestructura.Database.Entity.MySQL
{
    [Table("clientscontact")]
    public class ContactosEntity
    {
        [Key]
        public int id { get; set; }
        public int? Campo1 { get; set; }
        public int? Campo2 { get; set; }
        public string? Cliente { get; set; }
        public string? Campo4 { get; set; }
        public string? Telefono1 { get; set; }
        public string? Telefono2 { get; set; }
        public string? ClienteEmail { get; set; }
        public string? Direccion { get; set; }
        public string? CP { get; set; }
        public string? Provincia { get; set; }
        public string? Ciudad { get; set; }
        public DateTime Fecha1 { get; set; }
        public DateTime Fecha2 { get; set; }
        public int? campo5 { get; set; }
    }
}
