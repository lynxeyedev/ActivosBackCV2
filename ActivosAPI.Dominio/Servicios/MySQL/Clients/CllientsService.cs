using ActivosAPI.Comunes.Classes.Contratos.MySQL;
using ActivosAPI.Dominio.Servicios.MySQL.General;
using ActivosAPI.Infraestructura.Database.Entity.MySQL;
using ActivosAPI.Infraestructura.Repositorios.MySQL.General;
using AutoMapper;
using OfficeOpenXml;

namespace ActivosAPI.Dominio.Servicios.MySQL.Clients
{
    public class CllientsService : IActivosService<ClientsContract>, IClientsService
    {
        private readonly IActivosRepository<ClientsEntity> _clientRepo;
        private readonly IMapper _mapper;
        public CllientsService(IActivosRepository<ClientsEntity> clientRepo, IMapper mapper)
        {
            _clientRepo = clientRepo;
            _mapper = mapper;
        }

        public async Task GenerateExcelFile()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            List<ClientsEntity> clientes = await _clientRepo.GetAll();
            string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            string filePath = Path.Combine(downloadsFolder, "clientes.xlsx");
            FileInfo file = new FileInfo(filePath);
            using(ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Clientes");
                worksheet.Cells[1, 1].Value = "ID-Attendo";
                worksheet.Cells[1, 2].Value = "Campo 1";
                worksheet.Cells[1, 3].Value = "Codigo Cliente";
                worksheet.Cells[1, 4].Value = "NIF - CIF";
                worksheet.Cells[1, 5].Value = "Campo 2";
                worksheet.Cells[1, 6].Value = "Campo 3";
                worksheet.Cells[1, 7].Value = "Campo 4";
                worksheet.Cells[1, 8].Value = "Nombre 1";
                worksheet.Cells[1, 9].Value = "Nombre 2";
                worksheet.Cells[1, 10].Value = "Email";
                worksheet.Cells[1, 11].Value = "Telefono";
                worksheet.Cells[1, 12].Value = "direccion";
                worksheet.Cells[1, 13].Value = "CP";
                worksheet.Cells[1, 14].Value = "Provincia";
                worksheet.Cells[1, 15].Value = "Ciudad";
                worksheet.Cells[1, 16].Value = "Campo 5";
                worksheet.Cells[1, 17].Value = "Campo 6";
                worksheet.Cells[1, 18].Value = "Fecha 1";
                worksheet.Cells[1, 19].Value = "Fecha 2";
                worksheet.Cells[1, 20].Value = "Campo 7";
                worksheet.Cells[1, 21].Value = "Campo 8";
                worksheet.Cells[1, 22].Value = "Campo 9";
                for (int i = 0; i < clientes.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = clientes[i].idclient;
                    worksheet.Cells[i + 2, 2].Value = clientes[i].campo1;
                    worksheet.Cells[i + 2, 3].Value = clientes[i].CodCliente;
                    worksheet.Cells[i + 2, 4].Value = clientes[i].NIF;
                    worksheet.Cells[i + 2, 5].Value = clientes[i].campo2;
                    worksheet.Cells[i + 2, 6].Value = clientes[i].campo3;
                    worksheet.Cells[i + 2, 7].Value = clientes[i].campo4;
                    worksheet.Cells[i + 2, 8].Value = clientes[i].nombre1;
                    worksheet.Cells[i + 2, 9].Value = clientes[i].nombre2;
                    worksheet.Cells[i + 2, 10].Value = clientes[i].email;
                    worksheet.Cells[i + 2, 11].Value = clientes[i].telefono;
                    worksheet.Cells[i + 2, 12].Value = clientes[i].direccion;
                    worksheet.Cells[i + 2, 13].Value = clientes[i].CP;
                    worksheet.Cells[i + 2, 14].Value = clientes[i].provincia;
                    worksheet.Cells[i + 2, 15].Value = clientes[i].ciudad;
                    worksheet.Cells[i + 2, 16].Value = clientes[i].campo5;
                    worksheet.Cells[i + 2, 17].Value = clientes[i].campo6;
                    worksheet.Cells[i + 2, 18].Value = clientes[i].fecha1;
                    worksheet.Cells[i + 2, 19].Value = clientes[i].fecha2;
                    worksheet.Cells[i + 2, 20].Value = clientes[i].campo7;
                    worksheet.Cells[i + 2, 21].Value = clientes[i].campo8;
                    worksheet.Cells[i + 2, 22].Value = clientes[i].campo9;
                }
                package.Save();
            }
        }

        public async Task<List<ClientsContract>> GetAll()
        {
            List<ClientsEntity> clients = await _clientRepo.GetAll();
            return _mapper.Map<List<ClientsContract>>(clients);
        }

        public async Task<ClientsContract> GetById(int id)
        {
            ClientsEntity client = await _clientRepo.GetById(id);
            return _mapper.Map<ClientsContract>(client);
        }
    }
}
