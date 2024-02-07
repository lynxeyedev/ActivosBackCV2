using ActivosAPI.Comunes.Classes.Contratos.MySQL;
using ActivosAPI.Dominio.Servicios.MySQL.General;
using ActivosAPI.Infraestructura.Database.Entity.MySQL;
using ActivosAPI.Infraestructura.Repositorios.MySQL.General;
using AutoMapper;

namespace ActivosAPI.Dominio.Servicios.MySQL.Applicant
{
    public class AttendanService : IActivosService<ApplicantContract>
    {
        private readonly IActivosRepository<ApplicantEntity> _applicantRepo;
        private readonly IMapper _mapper;
        public AttendanService(IActivosRepository<ApplicantEntity> applicantRepo, IMapper mapper)
        {
            _applicantRepo = applicantRepo;
            _mapper = mapper;
        }

        public async Task<List<ApplicantContract>> GetAll()
        {
            List<ApplicantEntity> aplicnates = await _applicantRepo.GetAll();
            return _mapper.Map<List<ApplicantContract>>(aplicnates);
        }

        public async Task<ApplicantContract> GetById(int id)
        {
            ApplicantEntity aplicante = await _applicantRepo.GetById(id);
            if (aplicante != null)
            {
                return _mapper.Map<ApplicantContract>(aplicante);
            }
            else
            {
                throw new Exception("Aplicante no encontrado");
            }
        }
    }
}
