using Microsoft.AspNetCore.Mvc;

namespace Footwear.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        public IActionResult ProductList()
        {
            return View();
        }
    }
}
