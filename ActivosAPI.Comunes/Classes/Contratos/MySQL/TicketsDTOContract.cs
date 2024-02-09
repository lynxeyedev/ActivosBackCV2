namespace ActivosAPI.Comunes.Classes.Contratos.MySQL
{
    public class TicketsDTOContract
    {
        public int? idtickets {  get; set; }
        public string? Subject { get; set; }
        public int? idstatus { get; set; }
        public StatusDTOContract? status { get; set; }
        public int? idapplicant { get; set; }
        public ApplicantDTOContract? applicant { get; set; }
        public int? idcliente { get; set; }
        public ClientsDTOContract? clients { get; set; }
        public List<TimelineDTOContract>? timeline { get; set; }
        
    }
}
