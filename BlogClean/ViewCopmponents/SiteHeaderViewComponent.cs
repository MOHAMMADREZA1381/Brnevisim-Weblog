using Microsoft.AspNetCore.Mvc;
namespace BlogClean.ViewCpmponents
{
    public class SiteHeaderViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View("SiteHeader");
        }

    }
}
