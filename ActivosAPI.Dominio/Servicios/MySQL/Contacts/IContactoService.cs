using ActivosAPI.Comunes.Classes.Contratos.MySQL;

namespace ActivosAPI.Dominio.Servicios.MySQL.Contacts
{
    public interface IContactoService
    {
        Task<List<ContactosContract>> GetByIdCliente(int idCliente);
        Task<List<ClientsContactsContract>> GetAllClientsContact();
        Task<List<ClientsContactsContract>> GetClientContact(int idCliente);
    }
}
