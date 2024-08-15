using Footwear.UI.Areas.Admin.Dtos.CategoryDtos;
using Footwear.UI.Areas.Admin.Dtos.ProductDtos;
using Footwear.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;




namespace Footwear.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiBaseUrl _apiBaseUrl;

        public ProductController(IHttpClientFactory httpClientFactory, IOptions<ApiBaseUrl> apiBaseUrl)
        {
            _httpClientFactory = httpClientFactory;
            _apiBaseUrl = apiBaseUrl.Value;
        }


        public async Task<IActionResult> ProductList()
        
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.GetAsync("Products/GetProductWithInclude");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);
            if ((bool)jsonObject.responseIsSuccessfull)
            {
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonObject.responseData.ToString());
                return View(values);
            }
            return View();
        }
       
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.DeleteAsync("Products" + id);
            if (responseMessage.IsSuccessStatusCode)
            { 
                return RedirectToAction("ProductList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.GetAsync("Categories");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);
            if ((bool)jsonObject.responseIsSuccessfull)
            {
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonObject.responseData.ToString());
                ViewBag.CategoryList = values;
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var JsonObject = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(JsonObject, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("Products", stringContent);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);
            if ((bool)jsonObject.responseIsSuccessfull)
            {
                return RedirectToAction("ProductList");
            }
            else
            {
                List<string> errors = new List<string>();
                foreach (var item in jsonObject.responseErrors)
                {
                    errors.Add(item.ToString());
                }
                ViewBag.Errors = errors;
                return View();
            }

        }


        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {

            var clientCtgry = _httpClientFactory.CreateClient();
            clientCtgry.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessageCtgry = await clientCtgry.GetAsync("Categories");
            var jsonDataCtgry = await responseMessageCtgry.Content.ReadAsStringAsync();
            var jsonObjectCtgry = JsonConvert.DeserializeObject<dynamic>(jsonDataCtgry);
            if ((bool)jsonObjectCtgry.isSuccessfull)
            {
                var result = jsonObjectCtgry.data;
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(result.ToString());
                ViewBag.CategoryList = values;
            }
           


            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.GetAsync("Products" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);
            if ((bool)jsonObject.isSuccessfull)
            {
                var result = jsonObject.data;
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(result.ToString());
                return View(values);
            }
            return View();

        }


        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updtaeProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var JsonObject = JsonConvert.SerializeObject(updtaeProductDto);
            StringContent stringContent = new StringContent(JsonObject, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("Products", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductList");
            }
            return View();
        }


    }
}
