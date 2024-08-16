using Footwear.UI.Areas.Admin.Dtos.ProductDtos;
using Footwear.UI.Areas.Admin.Dtos.SocialMediaDtos;
using Footwear.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace Footwear.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialMediasController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiBaseUrl _apiBaseUrl;

        public SocialMediasController(IHttpClientFactory httpClientFactory, IOptions<ApiBaseUrl> options)
        {
            _httpClientFactory = httpClientFactory;
            _apiBaseUrl = options.Value;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.GetAsync("social-medias");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if ((bool)jsonObject.responseIsSuccessfull)
            {
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonObject.responseData.ToString());
                return View(values);
            }
            else
            {
                ViewBag.Message = jsonObject.responseMessage.ToString();
                return View(new List<ResultSocialMediaDto>());
            }

        }


        public IActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto model)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var data = JsonConvert.SerializeObject(model);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("social-medias",content);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if ((bool)jsonObject.responseIsSuccessfull)
            {
                return RedirectToAction("Index");
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
                return View();
            }

        }

        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.DeleteAsync("social-medias/"+id);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if ((bool)jsonObject.responseIsSuccessfull)
            {
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.GetAsync("social-medias/"+id);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if ((bool)jsonObject.responseIsSuccessfull)
            {
                var values = JsonConvert.DeserializeObject<GetByIdSocialMediaDto>(jsonObject.responseData.ToString());
                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto model)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var data = JsonConvert.SerializeObject(model);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("social-medias", content);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if ((bool)jsonObject.responseIsSuccessfull)
            {
                return RedirectToAction("Index");
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

    }
}
