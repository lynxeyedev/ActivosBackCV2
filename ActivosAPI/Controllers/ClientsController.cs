using ActivosAPI.Comunes.Classes.Contratos.MySQL;
using ActivosAPI.Dominio.Servicios.MySQL.Clients;
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
        private readonly IClientsService _clientsServ;
        public ClientsController(IActivosService<ClientsContract> servicio, IClientsService clientServ)
        {
            _servicio = servicio;
            _clientsServ = clientServ;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerClientesMySql()
        {
            return Ok(await _servicio.GetAll());
        }

        [HttpGet("ExcelFile")]
        public async Task<IActionResult> DesacrgarExcelClientes()
        {
            await _clientsServ.GenerateExcelFile();
            return Ok($"El archivo excel se descargo correctamente en la carpeta descargas");
        }
    }
}
