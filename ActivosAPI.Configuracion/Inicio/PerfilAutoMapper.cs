using ActivosAPI.Comunes.Classes.Contratos.MySQL;
using ActivosAPI.Comunes.Classes.Contratos.SQL;
using ActivosAPI.Infraestructura.Database.Entity.MySQL;
using ActivosAPI.Infraestructura.Database.Entity.SQL;
using AutoMapper;
namespace ActivosAPI.Configuracion.Inicio
{
    public class PerfilAutoMapper : Profile
    {
        public PerfilAutoMapper() 
        {
            CreateMap<ClientsEntity, ClientsContract>().ReverseMap();
            CreateMap<ClienteSQLEntity, ClientsSQLContract>().ReverseMap();
            CreateMap<ContactosEntity, ContactosContract>().ReverseMap();
            CreateMap<ContactoSQLEntity, ContactSQLContarct>().ReverseMap();
        }
    }
}
