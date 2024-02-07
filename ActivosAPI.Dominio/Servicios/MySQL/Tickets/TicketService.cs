using ActivosAPI.Comunes.Classes.Contratos.MySQL;
using ActivosAPI.Dominio.Servicios.MySQL.General;
using ActivosAPI.Infraestructura.Database.Entity.MySQL;
using ActivosAPI.Infraestructura.Repositorios.MySQL.General;
using ActivosAPI.Infraestructura.Repositorios.MySQL.Tickets;
using AutoMapper;

namespace ActivosAPI.Dominio.Servicios.MySQL.Tickets
{
    public class TicketService : IActivosService<TicketContract>, ITicketsService
    {
        private readonly IActivosRepository<TicketsEntity> _ticketRepo;
        private readonly IMapper _mapper;
        private readonly ITicketsRepository _ticket;
        public TicketService(IActivosRepository<TicketsEntity> ticketRepo, IMapper mapper, ITicketsRepository ticket)
        {
            _ticketRepo = ticketRepo;
            _mapper = mapper;
            _ticket = ticket;
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
    }
}
