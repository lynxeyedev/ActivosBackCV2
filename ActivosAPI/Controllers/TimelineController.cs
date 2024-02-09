using ActivosAPI.Comunes.Classes.Contratos.MySQL;
using ActivosAPI.Dominio.Servicios.MySQL.General;
using ActivosAPI.Dominio.Servicios.MySQL.Timeline;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActivosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimelineController : ControllerBase
    {
        private readonly IActivosService<TimelineContract> _timelineService;
        private readonly ITimelineService _timeline;
        public TimelineController(IActivosService<TimelineContract> timelineService,
            ITimelineService timeline)
        {
            _timelineService = timelineService;
            _timeline = timeline;
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerTimeline()
        {
            return Ok(await _timelineService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Timeline(int id)
        {
            return Ok(await _timelineService.GetById(id));
        }

        [HttpGet("timelineticket/{nTicket}")]
        public async Task<IActionResult> TicketTimeline(int nTicket)
        {
            return Ok(await _timeline.GetTimelineByNTicket(nTicket));
        }
    }
}
