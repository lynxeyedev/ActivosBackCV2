using ActivosAPI.Comunes.Classes.Contratos.SQL;
using ActivosAPI.Dominio.Servicios.SQL.General;
using ActivosAPI.Infraestructura.Database.Entity.MySQL;
using ActivosAPI.Infraestructura.Database.Entity.SQL;
using ActivosAPI.Infraestructura.Repositorios.MySQL.General;
using ActivosAPI.Infraestructura.Repositorios.SQL.Contacts;
using ActivosAPI.Infraestructura.Repositorios.SQL.General;
using AutoMapper;

namespace ActivosAPI.Dominio.Servicios.SQL.Contacts
{
    public class ContactSQLService :ICrudSQLService<ContactSQLContarct>, IContactSQLService
    {
        private readonly ICrudSQLRepository<ContactoSQLEntity> _contactRepo;
        private readonly IContactRepository _contactoSQL;
        private readonly ICrudSQLRepository<ClienteSQLEntity> _clienteRepo;
        private readonly IActivosRepository<ContactosEntity> _contactoMySQLRepo;
        private readonly IMapper _mapper;
        public ContactSQLService(ICrudSQLRepository<ContactoSQLEntity> contactRepo, IContactRepository contactoSQL, 
            ICrudSQLRepository<ClienteSQLEntity> clienteRepo, IMapper mapper, IActivosRepository<ContactosEntity> contactoMySQLRepo)
        {
            _contactRepo = contactRepo;
            _contactoSQL = contactoSQL;
            _clienteRepo = clienteRepo;
            _mapper = mapper;
            _contactoMySQLRepo = contactoMySQLRepo;
        }

        public async Task<List<ContactSQLContarct>> GetAll()
        {
            List<ContactoSQLEntity> listaContactos = await _contactRepo.GetAll();
            return _mapper.Map<List<ContactSQLContarct>>(listaContactos);
        }

        public async Task<ContactSQLContarct> GetById(int id)
        {
            ContactoSQLEntity contacto = await _contactRepo.GetById(id);
            if (contacto != null)
            {
                return _mapper.Map<ContactSQLContarct>(contacto);
            }
            else
            {
                ContactSQLContarct whiteContact = new ContactSQLContarct();
                return whiteContact;
            }
        }

        public Task<List<ClientDTOContract>> GetClientsAndContacts(int idCliente)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ContactSQLContarct>> GetContacts(int idCliente)
        {
            List<ContactoSQLEntity> contactos = await _contactoSQL.GetContactByClientId(idCliente);
            return _mapper.Map<List<ContactSQLContarct>>(contactos);
        }

        public async Task<ContactSQLContarct> Insert(ContactSQLContarct entity)
        {
            ContactoSQLEntity contacto = await _contactoSQL.getByEmail(entity.contacEmail);
            if (contacto == null)
            {
                await _contactRepo.Insert(_mapper.Map<ContactoSQLEntity>(entity));
                return entity;
            }
            else
            {
                return _mapper.Map<ContactSQLContarct>(contacto);
            }
        }

        public async Task<List<ContactSQLContarct>> InsertFromMySQL()
        {
            List<ContactoSQLEntity> listSQLContact = await _contactRepo.GetAll();
            if (listSQLContact != null)
            {
                await _contactRepo.Remove();
                List<ContactosEntity> contactosMySQL = await _contactoMySQLRepo.GetAll();
                List<ContactoSQLEntity> contactosSQL = new List<ContactoSQLEntity>();
                foreach(ContactosEntity contactMySQL in contactosMySQL)
                {
                    ContactoSQLEntity contactoSQL = new ContactoSQLEntity()
                    {
                        idCliente = contactMySQL.Campo1,
                        telf1 = contactMySQL.Telefono1,
                        telf2 = contactMySQL.Telefono2,
                        contacEmail = contactMySQL.ClienteEmail,
                        campo2 = contactMySQL.Campo2,
                        campo5 = contactMySQL.campo5,
                        idContactMySql = contactMySQL.id,
                    };
                    await _contactoSQL.InsertContactFromMySQL(contactoSQL);
                    contactosSQL.Add(contactoSQL);
                }
                return _mapper.Map<List<ContactSQLContarct>>(contactosSQL);
            }
            else
            {
                List<ContactosEntity> contactosMySQL = await _contactoMySQLRepo.GetAll();
                List<ContactoSQLEntity> contactosSQL = new List<ContactoSQLEntity>();
                foreach (ContactosEntity contactMySQL in contactosMySQL)
                {
                    ContactoSQLEntity contactoSQL = new ContactoSQLEntity()
                    {
                        idCliente = contactMySQL.Campo1,
                        telf1 = contactMySQL.Telefono1,
                        telf2 = contactMySQL.Telefono2,
                        contacEmail = contactMySQL.ClienteEmail,
                        campo2 = contactMySQL.Campo2,
                        campo5 = contactMySQL.campo5,
                        idContactMySql = contactMySQL.id,
                    };
                    await _contactoSQL.InsertContactFromMySQL(contactoSQL);
                    contactosSQL.Add(contactoSQL);
                }
                return _mapper.Map<List<ContactSQLContarct>>(contactosSQL);
            }
        }
    }
}
