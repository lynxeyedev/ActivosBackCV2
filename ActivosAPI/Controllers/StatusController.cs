using ActivosAPI.Comunes.Classes.Contratos.MySQL;
using ActivosAPI.Dominio.Servicios.MySQL.General;
using Microsoft.AspNetCore.Mvc;

namespace ActivosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IActivosService<StatusContract> _statusServicio;
        public StatusController(IActivosService<StatusContract> statusServicio)
        {
            _statusServicio = statusServicio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodosStatus()
        {
            return Ok(await _statusServicio.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerStatus(int id)
        {
            return Ok(await _statusServicio.GetById(id));
        }
    }
}
