using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;
        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductDtos>> GetAllProductAsync()
        {
            var query = "Select * from Product";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDtos>(query);
                return values.ToList();
            }
        }
        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            var query = "Select ProductID,Title,Price,City,District,CategoryName From Product inner join Category on Product.ProductCategory=CategoryID ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }
    }
}
