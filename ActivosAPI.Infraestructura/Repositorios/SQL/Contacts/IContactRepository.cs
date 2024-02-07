using ActivosAPI.Infraestructura.Database.Entity.MySQL;
using ActivosAPI.Infraestructura.Database.Entity.SQL;

namespace ActivosAPI.Infraestructura.Repositorios.SQL.Contacts
{
    public interface IContactRepository
    {
        Task InsertContactFromMySQL(ContactoSQLEntity entity);
        Task<ContactoSQLEntity> getByEmail (string email);
        Task<List<ContactoSQLEntity>> GetContactByClientId(int idClient);
    }
}
