using Footwear.UI.Areas.Admin.Dtos.AboutDtos;
using Footwear.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Footwear.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiBaseUrl _apiBaseUrl;

        public AboutController(IHttpClientFactory httpClientFactory, IOptions<ApiBaseUrl>options)
        {
            _httpClientFactory = httpClientFactory;
            _apiBaseUrl = options.Value;
        }

        public async Task <IActionResult> AboutList()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.GetAsync("abouts");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if((bool)jsonObject.responseIsSuccessfull)
            {
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonObject.responseData.ToString());
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.DeleteAsync("abouts/"+id);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if((bool)jsonObject.responseIsSuccessfull)
            {
                return RedirectToAction("AboutList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var data = JsonConvert.SerializeObject(dto);
            var stringContent = new StringContent(data,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("abouts", stringContent);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if((bool)jsonObject.responseIsSuccessfull)
            {
                return RedirectToAction("AboutList");
            }
            else
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
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.GetAsync($"abouts/"+id);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);
            
            if ((bool)jsonObject.responseIsSuccessfull)
            {
                var values = JsonConvert.DeserializeObject<GetByIdAboutDto>(jsonObject.responseData.ToString());
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var data = JsonConvert.SerializeObject(dto);
            var stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("abouts",stringContent);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if ((bool)jsonObject.responseIsSuccessfull)
            {
                return RedirectToAction("AboutList");
            }
            else
            {
                if(jsonObject.responseErrors is not null)
                {
                    List<string> errors = new List<string>();
                    foreach (var item in jsonObject.responseErrors)
                    {
                        errors.Add(item.ToString());
                    }
                    ViewBag.Errors = errors;
                }
            }
            return View();
        }
    }
}
