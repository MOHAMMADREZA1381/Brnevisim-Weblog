using Application.Interfaces;
using Domain.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Controllers
{
    public class AccountController : Controller
    {
        #region Service
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion


        [HttpGet("SignUp")]
        public async Task<IActionResult>Register()
        {
            return View();
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid & viewModel.Rules==true & await _userService.IsEmailRegistered(viewModel.Email)==false)
            {
                await _userService.Register(viewModel);
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("Email","کاربری با این ایمیل قبلا ثبت نام کرده است");
            }
            return View();
        }


        [HttpGet("SignIn")]
        public async Task<IActionResult> Login()
        {
            return View();
        }
    }
}
