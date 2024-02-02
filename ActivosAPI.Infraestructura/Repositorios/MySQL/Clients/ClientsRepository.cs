using ActivosAPI.Infraestructura.Database.Context;
using ActivosAPI.Infraestructura.Database.Entity.MySQL;
using ActivosAPI.Infraestructura.Repositorios.MySQL.General;
using Microsoft.EntityFrameworkCore;

namespace ActivosAPI.Infraestructura.Repositorios.MySQL.Clients
{
    public class ClientsRepository : IActivosRepository<ClientsEntity>
    {
        private readonly ActivosContext _context;
        public ClientsRepository( ActivosContext context)
        {
            _context = context;
        }

        public async Task<List<ClientsEntity>> GetAll()
        {
            return await _context.Clients.ToListAsync();
        }

        public Task<ClientsEntity> GetById(int id)
        {
            return _context.Clients
                .FirstOrDefaultAsync(c=>c.id == id);
        }
    }
}
