using ActivosAPI.Comunes.Classes.Contratos.SQL;

namespace ActivosAPI.Dominio.Servicios.SQL.Cliente
{
    public interface IClientsSQLService
    {
        Task<List<ClientsSQLContract>> InsertFromMySql();
    }
}
