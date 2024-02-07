using ActivosAPI.Comunes.Classes.Contratos.MySQL;
using ActivosAPI.Dominio.Servicios.MySQL.General;
using ActivosAPI.Dominio.Servicios.MySQL.Tickets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActivosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IActivosService<TicketContract> _ticketService;
        private readonly ITicketsService _ticket;
        public TicketsController(IActivosService<TicketContract> ticketService, ITicketsService ticket)
        {
            _ticketService = ticketService;
            _ticket = ticket;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerListadoTickets()
        {
            return Ok(await _ticketService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerTicket(int id)
        {
            return Ok(await _ticketService.GetById(id));
        }

        [HttpGet("estatus/{idstatus}")]
        public async Task<IActionResult> ObtenerTicketsPorStatus(int idstatus)
        {
            return Ok(await _ticket.GetTicketbyStatusid(idstatus));
        }
    }
}
