using ActivosAPI.Comunes.Classes.Contratos.MySQL;
using ActivosAPI.Dominio.Servicios.MySQL.General;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ActivosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IActivosService<ClientsContract> _servicio;
        public ClientsController(IActivosService<ClientsContract> servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerClientesMySql()
        {
            return Ok(await _servicio.GetAll());
        }
    }
}
