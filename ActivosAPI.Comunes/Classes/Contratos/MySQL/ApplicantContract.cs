namespace ActivosAPI.Comunes.Classes.Contratos.MySQL
{
    public class ApplicantContract
    {
        public int idapplicant { get; set; }
        public int? idcliente { get; set; }
        public string? nombre { get; set; }
        public string? email { get; set; }
        public DateTime? fechaapplicant { get; set; }
        public DateTime? fechaapplicant2 { get; set; }
        public int? mes { get; set; }
        public int? anio { get; set; }
    }
}
