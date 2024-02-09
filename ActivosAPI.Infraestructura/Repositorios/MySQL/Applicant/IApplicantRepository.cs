using ActivosAPI.Infraestructura.Database.Entity.MySQL;

namespace ActivosAPI.Infraestructura.Repositorios.MySQL.Applicant
{
    public interface IApplicantRepository
    {
        Task<List<ApplicantEntity>> GetApplicantByMonthYear(int mes, int anio);
    }
}
