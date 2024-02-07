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
        private readonly IActivosRepository<ClientsEntity> _clientsRepo;
        public ContactosService(IActivosRepository<ContactosEntity> contRepo,
            IMapper mapper, IActivosRepository<ClientsEntity> ClienteRepo,
            IContactoRepository contacto)
        {
            _contRepo = contRepo;
            _mapper = mapper;
            _contacto = contacto;
            _clientsRepo = ClienteRepo;
        }

        public async Task<List<ContactosContract>> GetAll()
        {
            List<ContactosEntity> contactos = await _contRepo.GetAll();
            return _mapper.Map<List<ContactosContract>>(contactos);
        }

        public Task<List<ClientsContactsContract>> GetAllClientsContact()
        {
            throw new NotImplementedException();
        }

        public async Task<ContactosContract> GetById(int id)
        {
            ContactosEntity contacto = await _contRepo.GetById(id);
            return _mapper.Map<ContactosContract>(contacto);
        }

        public async Task<List<ContactosContract>> GetByIdCliente(int idCliente)
        {
            List<ContactosEntity> contactos = await _contacto.GetContactoByIDCliente(idCliente);
            if (contactos != null)
            {
                return _mapper.Map<List<ContactosContract>>(contactos);
            }
            else
            {
                throw new Exception("Registro no encontrado en la base de datos");
            }
        }

        public async Task<List<ClientsContactsContract>> GetClientContact(int idCliente)
        {
            ClientsEntity cliente = await _clientsRepo.GetById(idCliente);
            if (cliente != null)
            {
                List<ClientsContactsContract> clienteMostrar = new List<ClientsContactsContract>();
                List<ContactosEntity> contactos = await _contacto.GetContactoByIDCliente(cliente.idclient);
                foreach (ContactosEntity contacto in contactos)
                {
                    if (contactos != null)
                    {
                        ClientsContactsContract clienteContacto = new ClientsContactsContract()
                        {
                            idclient = cliente.idclient,
                            CodCliente = cliente.CodCliente,
                            NIF = cliente.NIF,
                            campo2 = cliente.campo2,
                            campo3 = cliente.campo3,
                            campo4 = cliente.campo4,
                            nombre1 = cliente.nombre1,
                            nombre2 = cliente.nombre2,
                            email = cliente.email,
                            telefono = cliente.telefono,
                            CP = cliente.CP,
                            provincia = cliente.provincia,
                            ciudad = cliente.ciudad,
                            campo5 = cliente.campo5,
                            campo6 = cliente.campo6,
                            fecha1 = cliente.fecha1,
                            fecha2 = cliente.fecha2,
                            campo7 = cliente.campo7,
                            campo8 = cliente.campo8,
                            campo9 = cliente.campo9,
                            Contacts = new ContactosContract
                            {
                                id = contacto.id,
                                Campo1 = contacto.Campo1,
                                Campo2 = contacto.Campo2,
                                Cliente = contacto.Cliente,
                                Campo4 = contacto.Campo4,
                                Telefono1 = contacto.Telefono1,
                                Telefono2 = contacto.Telefono2,
                                ClienteEmail = contacto.ClienteEmail,
                                Direccion = contacto.Direccion,
                                CP = contacto.CP,
                                Provincia = contacto.Provincia,
                                Ciudad = contacto.Ciudad,
                                Fecha1 = contacto.Fecha1,
                                Fecha2 = contacto.Fecha2,
                                campo5 = contacto.campo5
                            }
                        };
                        clienteMostrar.Add(clienteContacto);
                    }
                }
                return clienteMostrar;
            }
            else
            {
                throw new Exception("Registro no existe en la BD");
            }
        }
    }
}
