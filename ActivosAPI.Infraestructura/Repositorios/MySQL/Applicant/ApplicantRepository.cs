﻿using ActivosAPI.Infraestructura.Database.Context;
using ActivosAPI.Infraestructura.Database.Entity.MySQL;
using ActivosAPI.Infraestructura.Repositorios.MySQL.General;
using Microsoft.EntityFrameworkCore;

namespace ActivosAPI.Infraestructura.Repositorios.MySQL.Applicant
{
    public class ApplicantRepository : IActivosRepository<ApplicantEntity>, IApplicantRepository
    {
        private readonly ActivosContext _context;
        public ApplicantRepository(ActivosContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicantEntity>> GetAll()
        {
            return await _context.Aplicante.ToListAsync();
        }

        public async Task<List<ApplicantEntity>> GetApplicantByMonthYear(int mes, int anio)
        {
            return await _context.Aplicante
                .Where(a => a.mes == mes && a.anio == anio).ToListAsync();
        }

        public async Task<ApplicantEntity> GetById(int id)
        {
            return await _context.Aplicante
                .FirstOrDefaultAsync(a => a.idapplicant == id);
        }
    }
}
