using ActivosAPI.Infraestructura.Database.Entity.MySQL;
using ActivosAPI.Infraestructura.Database.Entity.SQL;
using Microsoft.EntityFrameworkCore;

namespace ActivosAPI.Infraestructura.Database.Context
{
    public class ActivosSQLContext : DbContext
    {
        public ActivosSQLContext(DbContextOptions<ActivosSQLContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        #region [dbSet]
        public virtual DbSet<ClienteSQLEntity> ClienteSQLEntity { get; set; }
        public virtual DbSet<ContactoSQLEntity> ContactoSQLEntity { get; set; }
        #endregion
    }
}
