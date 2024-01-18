using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
