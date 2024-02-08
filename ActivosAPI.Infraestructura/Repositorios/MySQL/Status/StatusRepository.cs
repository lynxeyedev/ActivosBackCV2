
using ActivosAPI.Infraestructura.Database.Context;
using ActivosAPI.Infraestructura.Database.Entity.MySQL;
using ActivosAPI.Infraestructura.Repositorios.MySQL.General;
using Microsoft.EntityFrameworkCore;

namespace ActivosAPI.Infraestructura.Repositorios.MySQL.Status
{
    public class StatusRepository : IActivosRepository<StatusEntity>
    {
        private readonly ActivosContext _context;
        public StatusRepository( ActivosContext context )
        {
            _context = context;
        }

        public async Task<List<StatusEntity>> GetAll()
        {
            return await _context.Status.ToListAsync();
        }

        public async Task<StatusEntity> GetById(int id)
        {
            return await _context.Status
                .FirstOrDefaultAsync(s => s.id == id);
        }
    }
}
