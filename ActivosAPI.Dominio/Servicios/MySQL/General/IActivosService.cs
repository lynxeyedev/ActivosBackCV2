namespace ActivosAPI.Dominio.Servicios.MySQL.General
{
    public interface IActivosService<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
    }
}
