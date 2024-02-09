using ActivosAPI.Comunes.Classes.Contratos.MySQL;
using ActivosAPI.Dominio.Servicios.MySQL.Applicant;
using ActivosAPI.Dominio.Servicios.MySQL.General;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ActivosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IActivosService<ApplicantContract> _applicantService;
        private readonly AttendanService _servicioA;
        public ApplicantController(IActivosService<ApplicantContract> applicantService, AttendanService servicioA)
        {
            _applicantService = applicantService;
            _servicioA = servicioA;
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerAplicantes()
        {
            return Ok(await _applicantService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerAplicante(int id)
        {
            return Ok(await _applicantService.GetById(id));
        } 
        [HttpGet("porfecha/{mes}/{anio}")]
        public async Task<IActionResult> ObtenerPorFecha(int mes, int anio)
        {
            return Ok(await _servicioA.GetApplicantByMY(mes, anio));
        }
    }
}
