using ActivosAPI.Comunes.Classes.Contratos.SQL;

namespace ActivosAPI.Dominio.Servicios.SQL.Cliente
{
    public interface IClienteSQLService
    {
        Task<List<ClientsSQLContract>> InsertFromMySql();
    }
}
