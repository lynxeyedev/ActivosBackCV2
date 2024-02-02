namespace ActivosAPI.Dominio.Servicios.SQL.General
{
    public interface ICrudSQLService<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Insert(T entity);
    }
}
