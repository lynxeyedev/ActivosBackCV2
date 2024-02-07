namespace ActivosAPI.Comunes.Classes.Contratos.MySQL
{
    public class ClientsContactsContract
    {
        public int idclient { get; set; }
        public int? campo1 { get; set; }
        public string? CodCliente { get; set; }
        public string? NIF { get; set; }
        public int? campo2 { get; set; }
        public string? campo3 { get; set; }
        public string? campo4 { get; set; }
        public string? nombre1 { get; set; }
        public string? nombre2 { get; set; }
        public string? email { get; set; }
        public string? telefono { get; set; }
        public string? direccion { get; set; }
        public string? CP { get; set; }
        public string? provincia { get; set; }
        public string? ciudad { get; set; }
        public int? campo5 { get; set; }
        public string? campo6 { get; set; }
        public DateTime fecha1 { get; set; } = DateTime.Now;
        public DateTime fecha2 { get; set; } = DateTime.Now;
        public int? campo7 { get; set; }
        public int? campo8 { get; set; }
        public int? campo9 { get; set; }
        public ContactosContract? Contacts { get; set; }
    }
}
