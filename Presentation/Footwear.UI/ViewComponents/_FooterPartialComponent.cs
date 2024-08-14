using Microsoft.AspNetCore.Mvc;

namespace Footwear.UI.ViewComponents
{
    public class _FooterPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
