using ActivosAPI.Comunes.Classes.Contratos.MySQL;
using ActivosAPI.Dominio.Servicios.MySQL.Contacts;
using ActivosAPI.Dominio.Servicios.MySQL.General;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActivosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : ControllerBase
    {
        private readonly IActivosService<ContactosContract> _activosService;
        private readonly IContactoService _contactoServicio;
        public ContactosController(IActivosService<ContactosContract> activosService,
            IContactoService contatctoServicio)
        {
            _activosService = activosService;
            _contactoServicio = contatctoServicio;
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerContactos()
        {
            return Ok(await _activosService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerClientePorId(int id)
        {
            return Ok(await _activosService.GetById(id));
        }

        [HttpGet("cliente/{idcliente}")]
        public async Task<IActionResult> ObtenerContactoPorIdCliente(int idcliente)
        {
            return Ok(await _contactoServicio.GetByIdCliente(idcliente));
        }
    }
}
