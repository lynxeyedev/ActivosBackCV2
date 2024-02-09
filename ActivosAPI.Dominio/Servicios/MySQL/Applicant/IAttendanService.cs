using ActivosAPI.Comunes.Classes.Contratos.MySQL;

namespace ActivosAPI.Dominio.Servicios.MySQL.Applicant
{
    public interface IAttendanRepository
    {
        Task<List<ApplicantContract>> GetApplicantByMY(int mes, int anio);
    }
}
