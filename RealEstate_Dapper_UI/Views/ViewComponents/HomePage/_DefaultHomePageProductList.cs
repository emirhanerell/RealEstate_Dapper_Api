﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.Views.ViewComponents.HomePage
{
    
    public class _DefaultHomePageProductList:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultHomePageProductList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44328/api/Product/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDtos>>(jsonData); // DeserializeObject, Json'ı tablo formatına dönüştürür.
                return View(values);                                                           // Json'dan gelen datayı "ResultProductDtos" ile eşleştir
            }                                                                                      
            return View();
        }
    }
}
