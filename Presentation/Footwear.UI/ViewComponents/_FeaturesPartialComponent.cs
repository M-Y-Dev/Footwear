using Microsoft.AspNetCore.Mvc;

namespace Footwear.UI.ViewComponents
{
    public class _FeaturesPartialComponent :ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
