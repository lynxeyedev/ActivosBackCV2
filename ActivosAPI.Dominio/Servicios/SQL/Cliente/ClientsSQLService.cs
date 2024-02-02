using ActivosAPI.Comunes.Classes.Contratos.SQL;
using ActivosAPI.Dominio.Servicios.SQL.General;
using ActivosAPI.Infraestructura.Database.Entity.MySQL;
using ActivosAPI.Infraestructura.Database.Entity.SQL;
using ActivosAPI.Infraestructura.Repositorios.MySQL.General;
using ActivosAPI.Infraestructura.Repositorios.SQL.Clients;
using ActivosAPI.Infraestructura.Repositorios.SQL.General;
using AutoMapper;

namespace ActivosAPI.Dominio.Servicios.SQL.Cliente
{
    public class ClientsSQLService : ICrudSQLService<ClientsSQLRepository>, IClienteSQLService
    {
        private readonly ICrudSQLRepository<ClienteSQLEntity> _cSQLRepo;
        private readonly IClientSQLRepository _clienteSQL;
        private readonly IActivosRepository<ClientsEntity> _cMySqlRepo;
        private readonly IMapper _mapper;
        public ClientsSQLService(ICrudSQLRepository<ClienteSQLEntity> cSQLRepo, 
            IClientSQLRepository clienteSQL, IActivosRepository<ClientsEntity> 
            cMySqlRepo, IMapper mapper)
        {
            _cSQLRepo = cSQLRepo;
            _clienteSQL = clienteSQL;
            _cMySqlRepo = cMySqlRepo;
            _mapper = mapper;
        }

        public Task<List<ClientsSQLRepository>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ClientsSQLRepository> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ClientsSQLRepository> Insert(ClientsSQLRepository entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ClientsSQLContract>> InsertFromMySql()
        {
            List<ClientsEntity> clientsInMySQL = await _cMySqlRepo.GetAll();
            foreach (ClientsEntity clientMySQL in clientsInMySQL)
            {
                ClienteSQLEntity cliente = new ClienteSQLEntity()
                {
                    cliente = clientMySQL.NOMBRE1,
                    cif = clientMySQL.NIF,
                    provincia = clientMySQL.CIUDAD2,
                    ciudad = clientMySQL.CIUDAD,
                    cp = clientMySQL.CP,
                    telefono = clientMySQL.TELEFONO,
                    email = clientMySQL.EMAIL
                };
                await _clienteSQL.insertFromMySQL(cliente);
            }
            List<ClienteSQLEntity> clientesInSQL = await _cSQLRepo.GetAll();
            return _mapper.Map<List<ClientsSQLContract>>(clientesInSQL);
        }
    }
}
