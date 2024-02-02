using ActivosAPI.Infraestructura.Database.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace ActivosAPI.Configuracion.Inicio
{
    public class Container
    {
        public static void ConfiguracionDependecias(IServiceCollection services, IConfiguration configuration)
        {
            #region [Configuracion de AutoMapper]
            var configMapper = new MapperConfiguration(cfg => cfg.AddProfile(new PerfilAutoMapper()));
            var mapper = configMapper.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            #region [Inyeccion BD]
            IServiceCollection serviceCollection = services.AddDbContext<ActivosContext>(options => {
                options.UseMySql(
                    configuration.GetConnectionString("ConexionConDB"),
                    new MySqlServerVersion(new Version(11, 0, 2))
                    );
            });
            services.AddSingleton<IConfiguration>(configuration);

            //services.AddScoped<EcommerceContext, EcommerceContext>();    
            services.AddDbContext<ActivosSQLContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("ConexionConDBSQL")));
            services.AddSingleton<IConfiguration>(configuration);
            #endregion

            #region [Registro de Inyeccion de Dependecias]
            var assembliesToScan = new[]
            {
                Assembly.GetExecutingAssembly(),
                Assembly.Load("ActivosAPI.Dominio"),
                Assembly.Load("ActivosAPI.Infraestructura"),
                Assembly.Load("ActivosAPI.Comunes"),
            };
            services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
                .Where(c => c.Name.EndsWith("Repository") ||
                      c.Name.EndsWith("Service") ||
                      c.Name.EndsWith("Helper"))
                .AsPublicImplementedInterfaces();
            #endregion
        }
    }
}
