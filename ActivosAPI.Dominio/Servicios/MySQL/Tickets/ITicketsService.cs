using ActivosAPI.Comunes.Classes.Contratos.MySQL;

namespace ActivosAPI.Dominio.Servicios.MySQL.Tickets
{
    public interface ITicketsService
    {
        Task<List<TicketContract>> GetTicketbyStatusid(int statusid);
    }
}
