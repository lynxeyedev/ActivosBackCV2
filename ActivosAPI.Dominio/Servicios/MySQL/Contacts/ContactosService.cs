using ActivosAPI.Comunes.Classes.Contratos.MySQL;
using ActivosAPI.Dominio.Servicios.MySQL.General;
using ActivosAPI.Infraestructura.Database.Entity.MySQL;
using ActivosAPI.Infraestructura.Repositorios.MySQL.Contacts;
using ActivosAPI.Infraestructura.Repositorios.MySQL.General;
using AutoMapper;

namespace ActivosAPI.Dominio.Servicios.MySQL.Contacts
{
    public class ContactosService : IActivosService<ContactosContract>, IContactoService
    {
        private readonly IActivosRepository<ContactosEntity> _contRepo;
        private readonly IMapper _mapper;
        private readonly IContactoRepository _contacto;
        public ContactosService(IActivosRepository<ContactosEntity> contRepo, 
            IMapper mapper,
            IContactoRepository contacto)
        {
            _contRepo = contRepo;
            _mapper = mapper;
            _contacto = contacto;
        }

        public async Task<List<ContactosContract>> GetAll()
        {
            List<ContactosEntity> contactos = await _contRepo.GetAll();
            return _mapper.Map<List<ContactosContract>>(contactos);
        }

        public async Task<ContactosContract> GetById(int id)
        {
            ContactosEntity contacto = await _contRepo.GetById(id);
            return _mapper.Map<ContactosContract>(contacto);
        }

        public async Task<ContactosContract> GetByIdCliente(int idCliente)
        {
            ContactosEntity contacto = await _contacto.GetContactoByIDCliente(idCliente);
            if (contacto != null)
            {
                return _mapper.Map<ContactosContract>(contacto);
            }
            else
            {
                ContactosContract nocontacto = new ContactosContract();
                return nocontacto;
            }
        }
    }
}
