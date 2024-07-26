using RealEstate_Dapper_UI.Dtos.CategoryDtos;

namespace RealEstate_Dapper_UI.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDtos>> GetAllCategoryAsync();
        void CreateCategory(CreateCategoryDto createCategoryDto);
        public void DeleteCategory(int id);
        public void UpdateCategory(UpdateCategoryDto updateCategoryDto);
        Task<ResultCategoryDtos> GetCategoriesAsync(int id);
    }
}
