namespace ActivosAPI.Infraestructura.Repositorios.SQL.General
{
    public interface ICrudSQLRepository<T>
    {
        Task<T> GetById(int id);
        Task<T> Insert(T entity);
        Task<List<T>> GetAll();
        Task Remove();
    }
}
