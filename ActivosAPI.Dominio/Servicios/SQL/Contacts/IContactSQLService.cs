using ActivosAPI.Comunes.Classes.Contratos.SQL;

namespace ActivosAPI.Dominio.Servicios.SQL.Contacts
{
    public interface IContactSQLService
    {
        Task<List<ContactSQLContarct>> InsertFromMySQL();
        Task<List<ClientDTOContract>> GetClientsAndContacts(int idCliente);
        Task<List<ContactSQLContarct>> GetContacts(int idCliente);
    }
}
