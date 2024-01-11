using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
