using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_UI.Dtos.BottomGridDto;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
        void CreateBottomGrid(CreateBottomGridDto createBottomGridDto);
        public void DeleteBottomGrid(int id);
        public void UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto);
        Task<ResultBottomGridDto> GetBottomGridAsync(int id);
    }
}
