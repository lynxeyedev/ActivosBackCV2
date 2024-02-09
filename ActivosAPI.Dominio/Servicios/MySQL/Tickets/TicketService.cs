using ActivosAPI.Comunes.Classes.Contratos.MySQL;
using ActivosAPI.Dominio.Servicios.MySQL.Applicant;
using ActivosAPI.Dominio.Servicios.MySQL.General;
using ActivosAPI.Infraestructura.Database.Entity.MySQL;
using ActivosAPI.Infraestructura.Repositorios.MySQL.Applicant;
using ActivosAPI.Infraestructura.Repositorios.MySQL.General;
using ActivosAPI.Infraestructura.Repositorios.MySQL.Tickets;
using ActivosAPI.Infraestructura.Repositorios.MySQL.Timeline;
using AutoMapper;

namespace ActivosAPI.Dominio.Servicios.MySQL.Tickets
{
    public class TicketService : IActivosService<TicketContract>, ITicketsService
    {
        private readonly IActivosRepository<TicketsEntity> _ticketRepo;
        private readonly IMapper _mapper;
        private readonly ITicketsRepository _ticket;
        private readonly IActivosRepository<ClientsEntity> _clientsRepo;
        private readonly IActivosRepository<StatusEntity> _statusRepo;
        private readonly IActivosRepository<ApplicantEntity> _applicantRepo;
        private readonly ITimelineRepository _timelineRepo;
        private readonly IApplicantRepository _applicantS;
        public TicketService(IActivosRepository<TicketsEntity> ticketRepo, IMapper mapper, ITicketsRepository ticket,
            IActivosRepository<ClientsEntity> clientsRepo, IActivosRepository<StatusEntity> statusRepo,
            IActivosRepository<ApplicantEntity> applicantRepo, ITimelineRepository timelineRepo,
            IApplicantRepository applicantS)
        {
            _ticketRepo = ticketRepo;
            _mapper = mapper;
            _ticket = ticket;
            _clientsRepo = clientsRepo;
            _statusRepo = statusRepo;
            _applicantRepo = applicantRepo;
            _timelineRepo = timelineRepo;
            _applicantS = applicantS;
        }

        public async Task<List<TicketContract>> GetAll()
        {
            List<TicketsEntity> listaTicket = await _ticketRepo.GetAll();
            return _mapper.Map<List<TicketContract>>(listaTicket);
        }

        public async Task<TicketContract> GetById(int id)
        {
            TicketsEntity ticket = await _ticketRepo.GetById(id);
            if (ticket != null)
            {
                return _mapper.Map<TicketContract>(ticket);
            }
            else
            {
                throw new Exception("Ticket no Encontrado");
            }
        }

        public async Task<List<TicketContract>> GetTicketbyStatusid(int statusid)
        {
            List<TicketsEntity> tickets = await _ticket.GetByStatusId(statusid);
            if (tickets != null)
            {
                return _mapper.Map<List<TicketContract>>(tickets);
            }
            else { throw new Exception("No hay casos con ese estatus"); }
        }

        public async Task<TicketsDTOContract> GetTicketDetailByN(int nTicket)
        {
            TicketsDTOContract ticket = _mapper.Map<TicketsDTOContract>(await _ticketRepo.GetById(nTicket));
            if (ticket != null)
            {
                ticket.status = _mapper.Map<StatusDTOContract>(_statusRepo.GetById((int)ticket.idstatus).Result);
                ticket.applicant = _mapper.Map<ApplicantDTOContract>(_applicantRepo.GetById((int)ticket.idapplicant).Result);
                ticket.clients = _mapper.Map<ClientsDTOContract>(_clientsRepo.GetById((int)ticket.idcliente).Result);
                ticket.timeline = _mapper.Map<List<TimelineDTOContract>>(_timelineRepo.GetTimelinebyNTicket((int)ticket.idtickets).Result);
                foreach (TimelineDTOContract timeline in ticket.timeline)
                {

                }
                return ticket;
            }
            else
            {
                throw new Exception("No hay registro para este nuemero de ticket");
            }
        }
        public async Task<List<TicketsDTOContract>> GetTicketsByStatusTL(int statusid, int mes, int anio)
        {
            List<TicketsDTOContract> tiketsMostrar = new List<TicketsDTOContract>();
            List<ApplicantContract> listaApplicant = _mapper.Map<List<ApplicantContract>>(await _applicantS.GetApplicantByMonthYear(mes, anio));
            listaApplicant.ForEach(a =>
            {
                List<TicketsDTOContract> tickets = _mapper.Map<List<TicketsDTOContract>>(_ticket.GetByStatusId(statusid).Result);
                tickets.ForEach(ticket =>
                {
                    if(a.idapplicant == ticket.idapplicant)
                    {
                        TicketsDTOContract entity = new TicketsDTOContract();
                        entity.idtickets = ticket.idtickets;
                        entity.Subject = ticket.Subject;
                        entity.idstatus = ticket.idstatus;
                        entity.status = _mapper.Map<StatusDTOContract>(_statusRepo.GetById((int)ticket.idstatus).Result);
                        entity.idapplicant = ticket.idapplicant;
                        entity.applicant = _mapper.Map<ApplicantDTOContract>(_applicantRepo.GetById((int)ticket.idapplicant).Result);
                        entity.idcliente = ticket.idcliente;
                        entity.clients = _mapper.Map<ClientsDTOContract>(_clientsRepo.GetById((int)ticket.idcliente).Result);
                        entity.timeline = _mapper.Map<List<TimelineDTOContract>>(_timelineRepo.GetTimelinebyNTicket((int)ticket.idtickets).Result);
                        foreach (TimelineDTOContract item in entity.timeline)
                        {
                        }
                        tiketsMostrar.Add(entity);
                    }
                });
            });
            return tiketsMostrar;
        }

    }
}
