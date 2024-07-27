using Dapper;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Models.DapperContext;

namespace RealEstate_Dapper_UI.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;
         
        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "Insert into Category (CategoryName, CategoryStatus) values (@categoryName, @categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName",categoryDto.CategoryName);
            parameters.Add("@categoryStatus", categoryDto.Status);
            using (var connection = _context.CreateConnection()) 
            { 
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCategoryDtos>> GetAllCategoryAsync()
        {
            string query = "Select * From Category";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDtos>(query);
                return values.ToList();
            }
        }
        public async void DeleteCategory(int id)
        {
            string query = "Delete from Category Where CategoryID = @categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);
            using (var connection = _context.CreateConnection())
            { 
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var query = "Update Category Set CategoryName=@categoryName, CategoryStatus=@categoryStatus Where CategoryID = @categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName",updateCategoryDto.CategoryName);
            parameters.Add("@categoryStatus",updateCategoryDto.Status);
            parameters.Add("@categoryID", updateCategoryDto.CategoryID);
            using ( var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<ResultCategoryDtos> GetCategoriesAsync(int id)
        {
            var query = "Select * from Category Where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QuerySingleOrDefaultAsync<ResultCategoryDtos>(query,parameters);
                return values;
            }
        }
    }
}
