using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.BottomGridDto;

namespace RealEstate_Dapper_UI.Views.ViewComponents.HomePage
{
    public class _DefaultBottomGridComponentPartial:ViewComponent
    {
        public readonly IHttpClientFactory _httpClientBuilder;
        public _DefaultBottomGridComponentPartial(IHttpClientFactory httpClientBuilder)
        {
            _httpClientBuilder = httpClientBuilder;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientBuilder.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44328/api/BottomGrid");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBottomGridDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
