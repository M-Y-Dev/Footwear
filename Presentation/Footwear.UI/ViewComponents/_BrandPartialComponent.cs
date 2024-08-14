using Microsoft.AspNetCore.Mvc;

namespace Footwear.UI.ViewComponents
{
    public class _BrandPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
