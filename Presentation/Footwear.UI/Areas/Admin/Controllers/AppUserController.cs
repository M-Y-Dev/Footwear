using Footwear.UI.Areas.Admin.Dtos.AppRoleDtos;
using Footwear.UI.Areas.Admin.Dtos.CategoryDtos;
using Footwear.UI.Areas.Admin.Dtos.SocialMediaDtos;
using Footwear.UI.Areas.Admin.Dtos.UserDtos;
using Footwear.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Footwear.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AppUserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiBaseUrl _apiBaseUrl;

        public AppUserController(IHttpClientFactory httpClientFactory, IOptions<ApiBaseUrl> options)
        {
            _httpClientFactory = httpClientFactory;
            _apiBaseUrl = options.Value;
        }
        public async Task<IActionResult> UserList()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.GetAsync("users/GetUserWithRole");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if ((bool)jsonObject.responseIsSuccessfull)
            {
                var values = JsonConvert.DeserializeObject<List<ResultUserDto>>(jsonObject.responseData.ToString());
                return View(values);
            }
            else
            {
                ViewBag.Message = jsonObject.responseMessage.ToString();
                return View(new List<ResultUserDto>());
            }
        }
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.DeleteAsync($"users?id={id}");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if ((bool)jsonObject.responseIsSuccessfull)
            {
                return RedirectToAction("UserList");
            }

            return RedirectToAction("UserList");
        }
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser(int id)
        {
            await GetRoleList();

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.GetAsync($"users/{id}");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

       


            if ((bool)jsonObject.responseIsSuccessfull)
            {
                var values = JsonConvert.DeserializeObject<GetByIdUserDto>(jsonObject.responseData.ToString());
                return View(values);
            }
            return View();
        }


        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updateUser)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var data = JsonConvert.SerializeObject(updateUser);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("roles", content);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);

            if ((bool)jsonObject.responseIsSuccessfull)
            {
                return RedirectToAction("UserList");
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


        public async Task GetRoleList()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_apiBaseUrl.BaseUrl);
            var responseMessage = await client.GetAsync("roles");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonData);
            if ((bool)jsonObject.responseIsSuccessfull)
            {
                var values = JsonConvert.DeserializeObject<List<ResultRoleDto>>(jsonObject.responseData.ToString());
                ViewBag.RoleList = new SelectList(values, "Id", "RoleName");
            }
        }
    }

}
