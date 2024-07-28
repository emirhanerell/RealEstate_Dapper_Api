using Dapper;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        public readonly Context _context;
        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async void CreateService(CreateServiceDto createServiceDto)
        {
            string query = "Insert into Category (SerivceName, SerivceStatus) values (@serviceName, @serviceStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@sericeName", createServiceDto.ServiceName);
            parameters.Add("@serviceStatus", createServiceDto.ServiceStatus);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteService(int id)
        {
            string query = "Delete from Service Where ServiceID = @serviceID";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultServiceDtos>> GetAllServiceAsync()
        {
            string query = "Select * From Service";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDtos>(query);
                return values.ToList();
            }
        }

        public async Task<ResultServiceDtos> GetServiceAsync(int id)
        {
            var query = "Select * from Service Where ServiceID=@ServiceID";
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QuerySingleOrDefaultAsync<ResultServiceDtos>(query, parameters);
                return values;
            }
        }

        public async void UpdateService(UpdateServiceDto updateServiceDto)
        {
            var query = "Update Category Set ServiceName=@serviceName, ServiceStatus=@serviceStatus Where ServiceID = @serviceID";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceName", updateServiceDto.ServiceName);
            parameters.Add("@categoryStatus", updateServiceDto.ServiceStatus);
            parameters.Add("@serviceID", updateServiceDto.ServiceID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
