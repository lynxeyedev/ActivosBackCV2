using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivosAPI.Infraestructura.Database.Entity.MySQL
{
    [Table("Status")]
    public class StatusEntity
    {
        [Key]
        public int id {  get; set; }
        public string? status { get; set; }
    }
}
