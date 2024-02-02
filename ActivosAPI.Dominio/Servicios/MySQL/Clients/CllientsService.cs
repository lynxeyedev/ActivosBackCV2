using ActivosAPI.Comunes.Classes.Contratos.MySQL;
using ActivosAPI.Dominio.Servicios.MySQL.General;
using ActivosAPI.Infraestructura.Database.Entity.MySQL;
using ActivosAPI.Infraestructura.Repositorios.MySQL.General;
using AutoMapper;

namespace ActivosAPI.Dominio.Servicios.MySQL.Clients
{
    public class CllientsService : IActivosService<ClientsContract>
    {
        private readonly IActivosRepository<ClientsEntity> _clientRepo;
        private readonly IMapper _mapper;
        public CllientsService(IActivosRepository<ClientsEntity> clientRepo, IMapper mapper)
        {
            _clientRepo = clientRepo;
            _mapper = mapper;
        }

        public async Task<List<ClientsContract>> GetAll()
        {
            List<ClientsEntity> clients = await _clientRepo.GetAll();
            return _mapper.Map<List<ClientsContract>>(clients);
        }

        public async Task<ClientsContract> GetById(int id)
        {
            ClientsEntity client = await _clientRepo.GetById(id);
            return _mapper.Map<ClientsContract>(client);
        }
    }
}
