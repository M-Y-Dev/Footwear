using Footwear.UI.Areas.Admin.Dtos.AppRoleDtos;
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
    [Route("Admin/[controller]/[action]")]
    public class AppRoleController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiBaseUrl _apiBaseUrl;

        public AppRoleController(IHttpClientFactory httpClientFactory, IOptions<ApiBaseUrl> options)
        {
            _httpClientFactory = httpClientFactory;
            _apiBaseUrl = options.Value;
        }
        public async Task<IActionResult> RoleList()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress=new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.GetAsync("roles");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if ((bool)jsonObject.responseIsSuccessfull)
            {
                var values = JsonConvert.DeserializeObject<List<ResultRoleDto>>(jsonObject.responseData.ToString());
                return View(values);
            }
            else
            {
                ViewBag.Message = jsonObject.responseMessage.ToString();
                return View(new List<ResultSocialMediaDto>());
            }
        
        }

        [Route("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.DeleteAsync($"roles?id={id}");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if ((bool)jsonObject.responseIsSuccessfull)
            {
                return RedirectToAction("RoleList");
            }
            return RedirectToAction("RoleList");
        }

        public async Task<IActionResult> CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto roleDto)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var data = JsonConvert.SerializeObject(roleDto);
            var stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("roles", stringContent);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if ((bool)jsonObject.responseIsSuccessfull)
            {
                return RedirectToAction("RoleList");
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

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> UpdateRole(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.GetAsync("roles/" + id);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if ((bool)jsonObject.responseIsSuccessfull)
            {
                var values = JsonConvert.DeserializeObject<GetByIdRoleDto>(jsonObject.responseData.ToString());
                return View(values);
            }

            return View();
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> UpdateRole(UpdateRoleDto updateRole)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var data = JsonConvert.SerializeObject(updateRole);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("roles", content);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if ((bool)jsonObject.responseIsSuccessfull)
            {
                return RedirectToAction("RoleList");
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
