namespace ActivosAPI.Comunes.Classes.Contratos.SQL
{
    public class ClientsSQLContract
    {
        public int idCliente { get; set; }
        public string? cliente { get; set; }
        public string? cif { get; set; }
        public string? provincia { get; set; }
        public string? ciudad { get; set; }
        public string? cp { get; set; }
        public string? telefono { get; set; }
        public string? email { get; set; }
        public int? idcattendo { get; set; }
    }
}
