using ActivosAPI.Infraestructura.Database.Entity.MySQL;
using Microsoft.EntityFrameworkCore;

namespace ActivosAPI.Infraestructura.Database.Context
{
    public class ActivosContext : DbContext
    {
        public ActivosContext(DbContextOptions<ActivosContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        #region [DBSets]
        public virtual DbSet<ClientsEntity> Clients { get; set; }
        public virtual DbSet<ContactosEntity> Contactos { get; set; }
        public virtual DbSet<TicketsEntity> Tickets { get; set; }
        public virtual DbSet<ApplicantEntity> Aplicante { get; set; }
        public virtual DbSet<StatusEntity> Status { get; set; }
        #endregion
    }
}