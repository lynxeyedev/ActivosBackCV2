using ActivosAPI.Infraestructura.Database.Entity.MySQL;

namespace ActivosAPI.Infraestructura.Repositorios.MySQL.Contacts
{
    public interface IContactoRepository
    {
        Task<ContactosEntity> GetContactoByIDCliente(int idCliente);
    }
}
