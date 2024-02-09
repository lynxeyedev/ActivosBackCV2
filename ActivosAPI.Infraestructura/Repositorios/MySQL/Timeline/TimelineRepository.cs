using ActivosAPI.Infraestructura.Database.Context;
using ActivosAPI.Infraestructura.Database.Entity.MySQL;
using ActivosAPI.Infraestructura.Repositorios.MySQL.General;
using Microsoft.EntityFrameworkCore;

namespace ActivosAPI.Infraestructura.Repositorios.MySQL.Timeline
{
    public class TimelineRepository : IActivosRepository<TimelineEntity>, ITimelineRepository
    {
        private readonly ActivosContext _context;
        public TimelineRepository(ActivosContext context)
        {
            _context = context;
        }

        public async Task<List<TimelineEntity>> GetAll()
        {
            return await _context.Timeline.ToListAsync();
        }

        public async Task<TimelineEntity> GetById(int id)
        {
            return await _context.Timeline
                .FirstOrDefaultAsync(tl => tl.ID == id);
        }

        public async Task<List<TimelineEntity>> GetTimelinebyNTicket(int nTicket)
        {
            return await _context.Timeline
                .Where(tl => tl.idticket == nTicket).ToListAsync();
        }
    }
}
