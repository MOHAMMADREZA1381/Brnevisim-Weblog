using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Areas.AdminPanel.ViewComponents
{
    public class AdminFooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("AdminFooter");
        }
    }
}
