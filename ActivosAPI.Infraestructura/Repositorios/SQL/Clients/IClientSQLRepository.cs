using ActivosAPI.Infraestructura.Database.Entity.SQL;

namespace ActivosAPI.Infraestructura.Repositorios.SQL.Clients
{
    public interface IClientSQLRepository
    {
        Task insertFromMySQL(ClienteSQLEntity entity);
    }
}
