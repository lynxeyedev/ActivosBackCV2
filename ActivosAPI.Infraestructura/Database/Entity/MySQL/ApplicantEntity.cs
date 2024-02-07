using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivosAPI.Infraestructura.Database.Entity.MySQL
{
    [Table("Tickets_Applicants")]
    public class ApplicantEntity
    {
        [Key]
        public int ID { get; set; }
        public int? campo1 { get; set; }
        public string? campo2 { get; set; }
        public string? campo6 { get; set; }
        public DateTime? campo14 { get; set; }
        public DateTime? campo15 { get; set; }

    }
}
