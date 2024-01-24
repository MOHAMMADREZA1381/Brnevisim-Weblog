using Microsoft.AspNetCore.Mvc;

namespace BlogClean.ViewCpmponents
{
    public class SiteFooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("SiteFooter");
        }

    }
}
