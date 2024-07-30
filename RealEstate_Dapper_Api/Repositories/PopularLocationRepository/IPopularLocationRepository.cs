using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync();
        void CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto);
        public void DeletePopularLocation(int id);
        public void UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto);
        Task<ResultPopularLocationDto> GetPopularLocationAsync(int id);
    }
}
