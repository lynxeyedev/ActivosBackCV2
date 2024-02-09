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
            CreateMap<TicketsEntity, TicketContract>().ReverseMap();
            CreateMap<ApplicantEntity, ApplicantContract>().ReverseMap();
            CreateMap<StatusEntity, StatusContract>().ReverseMap();
            CreateMap<TimelineEntity, TimelineContract>().ReverseMap();
            CreateMap<TicketsEntity,TicketsDTOContract>().ReverseMap();
            CreateMap<StatusEntity, StatusDTOContract>().ReverseMap();
            CreateMap<ApplicantEntity, ApplicantDTOContract>().ReverseMap();
            CreateMap<ClientsEntity, ClientsDTOContract>().ReverseMap();
            CreateMap<TimelineEntity, TimelineDTOContract>().ReverseMap();
            
        }
    }
}
