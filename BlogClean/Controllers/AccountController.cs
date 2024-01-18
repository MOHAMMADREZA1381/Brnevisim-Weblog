using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet("SignUp")]
        public async Task<IActionResult>Register()
        {
            return View();
        }
        [HttpGet("SignIn")]
        public async Task<IActionResult> Login()
        {
            return View();
        }
    }
}
