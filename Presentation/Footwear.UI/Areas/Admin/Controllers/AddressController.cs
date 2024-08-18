using Footwear.UI.Areas.Admin.Dtos.AddressDtos;
using Footwear.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Footwear.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AddressController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiBaseUrl _apiBaseUrl;

        public AddressController(IHttpClientFactory httpClientFactory, IOptions<ApiBaseUrl> options)
        {
            _httpClientFactory = httpClientFactory;
            _apiBaseUrl = options.Value;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.GetAsync("addresses");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);
            if ((bool)jsonObject.responseIsSuccessfull)
            {
                var values = JsonConvert.DeserializeObject<List<ResultAddressDto>>(jsonObject.responseData.ToString());
                return View(values);
            }
            else
            {
                ViewBag.Message = jsonObject.responseMessage.ToString();
                return View(new List<ResultAddressDto>());
            }
        }
        public IActionResult CreateAddress()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressDto model)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var data = JsonConvert.SerializeObject(model);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("addresses", content);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);
            if ((bool)jsonObject.responseIsSuccessfull)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if(jsonObject.reponseErrors is not null)
                {
                    List<string> errors = new List<string>();
                    foreach (var error in jsonObject.reponseErrors)
                    {
                        errors.Add(error.ToString());
                    }
                    ViewBag.Errors = errors;
                }
                return View();
            }
        }

        public async Task<IActionResult> DeleteAddress(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.GetAsync("addresses/"+id);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if ((bool)jsonObject.responseIsSuccessfull)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateAddress(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.GetAsync($"addresses/{id}");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if ((bool)jsonObject.responseIsSuccessfull)
            {
                var values = JsonConvert.DeserializeObject<GetByIdAddressDto>(jsonObject.responseData.ToString());
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAddress(UpdateAddressDto model)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var data = JsonConvert.SerializeObject(model);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("addresses", content);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if ((bool)jsonObject.responseIsSuccessfull)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (jsonObject.reponseErrors is not null)
                {
                    List<string> errors = new List<string>();
                    foreach (var item in jsonObject.reponseErrors)
                    {
                        errors.Add(item.ToString());
                    }
                    ViewBag.Errors = errors;
                }
                return View();
            }
        }
    }
}
