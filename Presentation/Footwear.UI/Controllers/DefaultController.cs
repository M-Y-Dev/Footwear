using Microsoft.AspNetCore.Mvc;

namespace Footwear.UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
