namespace ActivosAPI.Comunes.Classes.Contratos.SQL
{
    public class ClientDTOContract
    {
        public int? idcattendo { get; set; }
        public string? cliente { get; set; }
        public ContactDTOContract? contact { get; set; }
    }
}
