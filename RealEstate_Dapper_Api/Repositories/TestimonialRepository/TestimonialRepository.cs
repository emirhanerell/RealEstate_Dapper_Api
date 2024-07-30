using Dapper;
using RealEstate_Dapper_Api.Dtos.TestimonialDto;
using RealEstate_Dapper_UI.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepository
{
    public class TestimonialRepository : ITestimonialRepository
    {
        public readonly Context _context;
        public TestimonialRepository(Context context)
        {
            _context = context;
        }

        public void CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteTestimonial(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            string query = "Select * from Testimonial";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTestimonialDto>(query);
                return values.ToList();
            }
        }

        public async Task<ResultTestimonialDto> GetTestimonialAsync(int id)
        {
            string query = "Select * from Testimonial Where TestimonialID = @testimonialID";
            var parameters = new DynamicParameters();
            parameters.Add("@testimonialID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QuerySingleOrDefaultAsync<ResultTestimonialDto>(query, parameters);
                return values;
            }
        }

        public void UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            throw new NotImplementedException();
        }
    }
}
