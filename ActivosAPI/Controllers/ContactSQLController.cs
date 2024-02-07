using ActivosAPI.Comunes.Classes.Contratos.SQL;
using ActivosAPI.Dominio.Servicios.SQL.Contacts;
using ActivosAPI.Dominio.Servicios.SQL.General;
using Microsoft.AspNetCore.Mvc;

namespace ActivosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactSQLController : ControllerBase
    {
        private readonly ICrudSQLService<ContactSQLContarct> _servicio;
        private readonly IContactSQLService _servicioContact;
        public ContactSQLController(ICrudSQLService<ContactSQLContarct> servicio, IContactSQLService servicioContact)
        {
            _servicio = servicio;
            _servicioContact = servicioContact;
        }

        [HttpGet]
        public async Task<IActionResult> obtenerContactos()
        {
            return Ok(await _servicio.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerContacto(int id)
        {
            return Ok(await _servicio.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CrearContato(ContactSQLContarct entity)
        {
            return Ok(await _servicio.Insert(entity));
        }
        [HttpPost("insertonetime")]
        public async Task<IActionResult> CrearContactoUnaVez()
        {
            return Ok(await _servicioContact.InsertFromMySQL());
        }

        [HttpGet("Contactos/{idCliente}")]
        public async Task<IActionResult> ObtenerContactosPorIdCliente(int idCliente)
        {
            return Ok(await _servicioContact.GetContacts(idCliente));
        }
    }
}
