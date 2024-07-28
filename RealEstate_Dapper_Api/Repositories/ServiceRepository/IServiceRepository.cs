using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDtos>> GetAllServiceAsync();
        void CreateService(CreateServiceDto createServiceDto);
        public void DeleteService(int id);
        public void UpdateService(UpdateServiceDto updateServiceDto);
        Task<ResultServiceDtos> GetServiceAsync(int id);
    }
}
