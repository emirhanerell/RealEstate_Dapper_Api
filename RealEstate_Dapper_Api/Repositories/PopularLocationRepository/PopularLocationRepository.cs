using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_UI.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        public readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public void CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            throw new NotImplementedException();
        }

        public void DeletePopularLocation(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
        {
            string query = "Select * from PopularLocation";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();
            }
        }

        public async Task<ResultPopularLocationDto> GetPopularLocationAsync(int id)
        {
            string query = "Select * from PopularLocation Where PopularLocationID = @popularLocationID";
            var parameters = new DynamicParameters();
            parameters.Add("@popularLocationID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QuerySingleOrDefaultAsync<ResultPopularLocationDto>(query,parameters);
                return values;
            }
        }

        public void UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            throw new NotImplementedException();
        }
    }
}
