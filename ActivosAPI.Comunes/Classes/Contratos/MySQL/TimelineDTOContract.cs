namespace ActivosAPI.Comunes.Classes.Contratos.MySQL
{
    public class TimelineDTOContract
    {
        public int id { get; set; }
        public int idticket { get; set; }
        public string? Accion {  get; set; }
        public DateTime? FechaEnvio { get; set; }
        public string? agente { get; set; }
    }
}
