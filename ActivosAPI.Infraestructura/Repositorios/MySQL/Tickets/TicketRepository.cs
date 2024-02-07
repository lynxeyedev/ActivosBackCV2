using ActivosAPI.Infraestructura.Database.Context;
using ActivosAPI.Infraestructura.Database.Entity.MySQL;
using ActivosAPI.Infraestructura.Repositorios.MySQL.General;
using Microsoft.EntityFrameworkCore;

namespace ActivosAPI.Infraestructura.Repositorios.MySQL.Tickets
{
    public class TicketRepository : IActivosRepository<TicketsEntity>, ITicketsRepository
    {
        private readonly ActivosContext _context;
        public TicketRepository( ActivosContext context)
        {
            _context = context;
        }

        public async Task<List<TicketsEntity>> GetAll()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<TicketsEntity> GetById(int id)
        {
            return await _context.Tickets
                .FirstOrDefaultAsync(t => t.ID == id);
        }

        public async Task<List<TicketsEntity>> GetByStatusId(int statusId)
        {
            return await _context.Tickets
                .Where(t => t.idstatus == statusId).ToListAsync();
        }
    }
}
