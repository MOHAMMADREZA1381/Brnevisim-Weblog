using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Areas.AdminPanel.ViewComponents
{
    public class AdminHeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("AdminHeader");
        }
    }
}
