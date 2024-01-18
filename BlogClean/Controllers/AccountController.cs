using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}
