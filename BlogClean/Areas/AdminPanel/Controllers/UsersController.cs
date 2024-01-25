using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
