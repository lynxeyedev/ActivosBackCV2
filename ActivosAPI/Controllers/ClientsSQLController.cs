using ActivosAPI.Comunes.Classes.Contratos.SQL;
using ActivosAPI.Dominio.Servicios.SQL.Cliente;
using ActivosAPI.Dominio.Servicios.SQL.General;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActivosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsSQLController : ControllerBase
    {
        private readonly ICrudSQLService<ClientsSQLContract> _servicio;
        private readonly IClientsSQLService _clienteServicio;
        public ClientsSQLController(ICrudSQLService<ClientsSQLContract> servicio, 
            IClientsSQLService clienteServicio)
        {
            _servicio = servicio;
            _clienteServicio = clienteServicio;
        }

        [HttpPost]
        public async Task<IActionResult> AgregarClientesSQL()
        {
            return Ok(await _clienteServicio.InsertFromMySql());
        }
    }
}
