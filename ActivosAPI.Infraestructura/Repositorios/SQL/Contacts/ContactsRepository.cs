using ActivosAPI.Infraestructura.Database.Context;
using ActivosAPI.Infraestructura.Database.Entity.SQL;
using ActivosAPI.Infraestructura.Repositorios.SQL.General;
using Microsoft.EntityFrameworkCore;

namespace ActivosAPI.Infraestructura.Repositorios.SQL.Contacts
{
    public class ContactsRepository : ICrudSQLRepository<ContactoSQLEntity>, IContactRepository
    {
        private readonly ActivosSQLContext _context;
        public ContactsRepository( ActivosSQLContext context )
        {
            _context = context;
        }

        public async Task<List<ContactoSQLEntity>> GetAll()
        {
            return await _context.ContactoSQLEntity.ToListAsync();
        }

        public async Task<ContactoSQLEntity> getByEmail(string email)
        {
            return await _context.ContactoSQLEntity
               .FirstOrDefaultAsync(c => c.contacEmail == email);
        }
        public async Task<ContactoSQLEntity> GetById(int id)
        {
            return await _context.ContactoSQLEntity
                .FirstOrDefaultAsync(c => c.idContact == id);
        }

        public async Task<List<ContactoSQLEntity>> GetContactByClientId(int idClient)
        {
            return await _context.ContactoSQLEntity
                .Where(c => c.idCliente == idClient).ToListAsync();
        }

        public async Task<ContactoSQLEntity> Insert(ContactoSQLEntity entity)
        {
            _context.ContactoSQLEntity.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task InsertContactFromMySQL(ContactoSQLEntity entity)
        {
            _context.ContactoSQLEntity.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Remove()
        {
            await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Contacts");
        }
    }
}
