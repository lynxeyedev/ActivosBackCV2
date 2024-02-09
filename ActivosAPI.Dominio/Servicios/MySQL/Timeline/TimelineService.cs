using ActivosAPI.Comunes.Classes.Contratos.MySQL;
using ActivosAPI.Dominio.Servicios.MySQL.General;
using ActivosAPI.Infraestructura.Database.Entity.MySQL;
using ActivosAPI.Infraestructura.Repositorios.MySQL.General;
using ActivosAPI.Infraestructura.Repositorios.MySQL.Timeline;
using AutoMapper;

namespace ActivosAPI.Dominio.Servicios.MySQL.Timeline
{
    public class TimelineService : IActivosService<TimelineContract>, ITimelineService
    {
        private readonly IActivosRepository<TimelineEntity> _timelineRepo;
        private readonly IMapper _mapper;
        private readonly ITimelineRepository _timeline;
        public TimelineService(IActivosRepository<TimelineEntity> timelineRepo, IMapper mapper,
            ITimelineRepository timeline)
        {
            _timelineRepo = timelineRepo;
            _mapper = mapper;
            _timeline = timeline;
        }

        public async Task<List<TimelineContract>> GetAll()
        {
            List<TimelineEntity> listaTimelist = await _timelineRepo.GetAll();
            return _mapper.Map<List<TimelineContract>>(listaTimelist);
        }

        public async Task<TimelineContract> GetById(int id)
        {
            TimelineEntity timeline = await _timelineRepo.GetById(id);
            if (timeline != null) 
            {
                return _mapper.Map<TimelineContract>(timeline);
            }
            else
            {
                throw new Exception("Registro no encontrado");
            }
        }

        public async Task<List<TimelineContract>> GetTimelineByNTicket(int nTicket)
        {
            List<TimelineEntity> listado = await _timeline.GetTimelinebyNTicket(nTicket);
            if (listado != null)
            {
                return _mapper.Map<List<TimelineContract>>(listado);
            }
            else
            {
                throw new Exception("No existe TimeLine de para este ticket");
            }
        }
    }
}
