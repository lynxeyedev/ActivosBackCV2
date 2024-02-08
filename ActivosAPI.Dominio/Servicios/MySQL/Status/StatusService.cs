using ActivosAPI.Comunes.Classes.Contratos.MySQL;
using ActivosAPI.Dominio.Servicios.MySQL.General;
using ActivosAPI.Infraestructura.Database.Entity.MySQL;
using ActivosAPI.Infraestructura.Repositorios.MySQL.General;
using AutoMapper;

namespace ActivosAPI.Dominio.Servicios.MySQL.Status
{
    public class StatusService : IActivosService<StatusContract>
    {
        private readonly IActivosRepository<StatusEntity> _statusRepo;
        private readonly IMapper _mapper;
        public StatusService(IActivosRepository<StatusEntity> statusRepo, IMapper mapper)
        {
            _statusRepo = statusRepo;
            _mapper = mapper;
        }

        public async Task<List<StatusContract>> GetAll()
        {
            List<StatusEntity> listadoStatus = await _statusRepo.GetAll();
            return _mapper.Map<List<StatusContract>>(listadoStatus);
        }

        public async Task<StatusContract> GetById(int id)
        {
            StatusEntity status = await _statusRepo.GetById(id);
            if (status != null)
            {
                return _mapper.Map<StatusContract>(status);
            }
            else
            {
                throw new Exception("Registro no Encontrado");
            }
        }
    }
}
