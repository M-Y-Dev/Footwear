using Footwear.UI.Areas.Admin.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;




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


        public async Task<IActionResult> ProductList()
        
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7275/api/products/GetProductWithCategory");

            //response message base adresden sonra değişecek.

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);
            
            if ((bool)jsonObject.responseIsSuccessfull)
            {
                var result = jsonObject.responseData;
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(result.ToString());
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7275/api/products/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductList");
            }
            return View();
        }

        
    }
}
