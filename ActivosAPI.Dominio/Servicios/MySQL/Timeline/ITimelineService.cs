using ActivosAPI.Comunes.Classes.Contratos.MySQL;

namespace ActivosAPI.Dominio.Servicios.MySQL.Timeline
{
    public interface ITimelineService
    {
        Task<List<TimelineContract>> GetTimelineByNTicket(int nTicket);
    }
}
