using Footwear.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Footwear.UI.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }
      
    }
}
