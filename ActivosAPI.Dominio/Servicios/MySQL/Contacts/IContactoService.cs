using ActivosAPI.Comunes.Classes.Contratos.MySQL;

namespace ActivosAPI.Dominio.Servicios.MySQL.Contacts
{
    public interface IContactoService
    {
        Task<ContactosContract> GetByIdCliente(int idCliente);
    }
}
