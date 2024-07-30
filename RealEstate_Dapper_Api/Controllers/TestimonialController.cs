using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.TestimonialRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        public readonly ITestimonialRepository _testimonialRepository;
        public TestimonialController(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTestimonial() 
        {
            var value = await _testimonialRepository.GetAllTestimonialAsync();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            var value = await _testimonialRepository.GetTestimonialAsync(id);
            return Ok(value);
        }
    }
}
