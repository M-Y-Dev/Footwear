using Footwear.UI.Areas.Admin.Dtos.CategoryDtos;
using Footwear.UI.Areas.Admin.Dtos.ProductDtos;
using Footwear.UI.Areas.Admin.Dtos.SocialMediaDtos;
using Footwear.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Reflection;
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
            var responseMessage = await client.GetAsync("products/GetProductWithInclude");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);
            if ((bool)jsonObject.responseIsSuccessfull)
            {
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonObject.responseData.ToString());
                return View(values);
            }
            else
            {
                ViewBag.Message = jsonObject.responseMessage.ToString();
                return View(new List<ResultProductDto>());
            }
        }
       
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.DeleteAsync("products/"+id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if ((bool)jsonObject.responseIsSuccessfull)
            {
                return RedirectToAction("ProductList");
            }

            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {

            await GetCategoryList();
            return View();
            
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var JsonObject = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(JsonObject, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("products", stringContent);
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

            await GetCategoryList();

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.GetAsync("products/"+id);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if ((bool)jsonObject.responseIsSuccessfull)
            {
                var values = JsonConvert.DeserializeObject<GetByIdProductDto>(jsonObject.responseData.ToString());
                return View(values);
            }

            return View();

        }


        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto model)
        {

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var data = JsonConvert.SerializeObject(model);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("products", content);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if ((bool)jsonObject.responseIsSuccessfull)
            {
                return RedirectToAction("ProductList");
            }
            else
            {
                if (jsonObject.responseErrors is not null)
                {
                    List<string> errors = new List<string>();
                    foreach (var item in jsonObject.responseErrors)
                    {
                        errors.Add(item.ToString());
                    }
                    ViewBag.Errors = errors;
                }

                return View();
            }
        }

        public async Task GetCategoryList()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.GetAsync("Categories");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);
            if ((bool)jsonObject.responseIsSuccessfull)
            {
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonObject.responseData.ToString());
                ViewBag.CategoryList = new SelectList(values,"Id","CategoryName");
            }

        }
    }
}
