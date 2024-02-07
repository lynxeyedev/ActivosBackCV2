using ActivosAPI.Infraestructura.Database.Entity.MySQL;
namespace ActivosAPI.Infraestructura.Repositorios.MySQL.Tickets
{
    public interface ITicketsRepository
    {
        Task<List<TicketsEntity>> GetByStatusId(int statusId);
    }
}
