using ActivosAPI.Infraestructura.Database.Context;
using ActivosAPI.Infraestructura.Database.Entity.SQL;
using ActivosAPI.Infraestructura.Repositorios.SQL.General;
using Microsoft.EntityFrameworkCore;

namespace ActivosAPI.Infraestructura.Repositorios.SQL.Clients
{
    public class ClientsSQLRepository : ICrudSQLRepository<ClienteSQLEntity>, IClientSQLRepository
    {
        private readonly ActivosSQLContext _context;
        public ClientsSQLRepository(ActivosSQLContext context)
        {
            _context = context;
        }

        public Task<List<ClienteSQLEntity>> GetAll()
        {
            return _context.ClienteSQLEntity.ToListAsync();
        }

        public Task<ClienteSQLEntity> GetById(int id)
        {
            return _context.ClienteSQLEntity
                .FirstOrDefaultAsync(c => c.idCliente == id);
        }

        public async Task<ClienteSQLEntity> Insert(ClienteSQLEntity entity)
        {
            _context.ClienteSQLEntity.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task insertFromMySQL(ClienteSQLEntity entity)
        {
            _context.ClienteSQLEntity.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Remove()
        {
            await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Clientes");
        }
    }
}
