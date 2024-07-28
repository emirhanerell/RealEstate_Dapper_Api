using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;

namespace RealEstate_Dapper_UI.Views.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientBuilder;

        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientBuilder)
        {
            _httpClientBuilder = httpClientBuilder;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientBuilder.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44328/api/WhoWeAreDetail");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDtos>>(jsonData);
                ViewBag.Title = value.Select(x => x.Title).FirstOrDefault();
                ViewBag.Subtitle = value.Select(x=> x.Subtitle).FirstOrDefault();
                ViewBag.Description1 = value.Select(x=> x.Description1).FirstOrDefault();
                ViewBag.Description2 = value.Select(x => x.Description2).FirstOrDefault();
                return View();
            }
            return View();
        }
    }
}
