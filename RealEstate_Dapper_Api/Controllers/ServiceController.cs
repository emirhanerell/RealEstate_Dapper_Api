using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;

namespace RealEstate_Dapper_Api.Controllers8
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        public readonly IServiceRepository _serviceRepository;

        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            var values = await _serviceRepository.GetAllServiceAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddService(CreateServiceDto createServiceDto)
        {
            _serviceRepository.CreateService(createServiceDto);
            return Ok("Başarılı Bir şekilde Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteService(int id)
        {
            _serviceRepository.DeleteService(id);
            return Ok("Başarılı bir şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UptadeService(UpdateServiceDto updateServiceDto)
        {
            _serviceRepository.UpdateService(updateServiceDto);
            return Ok("Başarılı bir şekilde Güncellendi");
        }
    }
}
