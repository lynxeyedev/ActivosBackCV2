using ActivosAPI.Infraestructura.Database.Entity.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivosAPI.Infraestructura.Repositorios.MySQL.Timeline
{
    public interface ITimelineRepository
    {
        Task<List<TimelineEntity>> GetTimelinebyNTicket(int nTicket);
    }
}
