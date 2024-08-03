﻿using Footwear.UI.Areas.Admin.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList.Extensions;


namespace Footwear.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> ProductList(int page = 1,int pageSize=5)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7275/api/products/GetProductWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values.ToPagedList(page, pageSize));
            }
            return View();
        }
    }
}
