namespace ActivosAPI.Infraestructura.Repositorios.MySQL.General
{
    public interface IActivosRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
    }
}
