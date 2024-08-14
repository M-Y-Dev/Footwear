using Microsoft.AspNetCore.Mvc;

namespace Footwear.UI.ViewComponents
{
    public class _RecentProductPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
