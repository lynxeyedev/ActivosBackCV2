using ActivosAPI.Infraestructura.Database.Context;
using ActivosAPI.Infraestructura.Database.Entity.MySQL;
using ActivosAPI.Infraestructura.Repositorios.MySQL.General;
using Microsoft.EntityFrameworkCore;

namespace ActivosAPI.Infraestructura.Repositorios.MySQL.Contacts
{
    public class ContactsRepository : IActivosRepository<ContactosEntity>, IContactoRepository
    {
        private readonly ActivosContext _context;
        public ContactsRepository( ActivosContext context )
        {
            _context = context;
        }

        public Task<List<ContactosEntity>> GetAll()
        {
            return _context.Contactos.ToListAsync();
        }

        public Task<ContactosEntity> GetById(int id)
        {
            return _context.Contactos
                .FirstOrDefaultAsync(con => con.id == id);
        }

        public async Task<List<ContactosEntity>> GetContactoByIDCliente(int idCliente)
        {
            return await _context.Contactos
                .Where(cont => cont.Campo1 == idCliente).ToListAsync();
        }
    }
}
