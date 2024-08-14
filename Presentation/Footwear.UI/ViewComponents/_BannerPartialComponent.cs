using Microsoft.AspNetCore.Mvc;

namespace Footwear.UI.ViewComponents
{
    public class _BannerPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
