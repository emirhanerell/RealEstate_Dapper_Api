using RealEstate_Dapper_Api.Dtos.TestimonialDto;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepository
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
        void CreateTestimonial(CreateTestimonialDto createTestimonialDto);
        public void DeleteTestimonial(int id);
        public void UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto);
        Task<ResultTestimonialDto> GetTestimonialAsync(int id);
    }
}
