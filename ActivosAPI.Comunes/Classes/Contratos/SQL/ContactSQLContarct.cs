using System.ComponentModel.DataAnnotations;

namespace ActivosAPI.Comunes.Classes.Contratos.SQL
{
    public class ContactSQLContarct
    {
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
