using Microsoft.AspNetCore.Mvc;

namespace Footwear.UI.Areas.Admin.ViewComponents
{
    public class _ScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

}
