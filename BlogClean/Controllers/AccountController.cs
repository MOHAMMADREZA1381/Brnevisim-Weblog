using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using Application.Interfaces;
using Application.SenderEmail;
using Domain.Models;
using Domain.ViewModels.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace BlogClean.Controllers
{
    public class AccountController : Controller
    {
        #region Service
        private readonly IUserService _userService;
        private readonly IViewRenderService _view;
        public AccountController(IUserService userService,IViewRenderService view)
        {
            _userService = userService;
            _view = view;
        }
        #endregion


        [HttpGet("SignUp")]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid & viewModel.Rules == true & await _userService.IsEmailRegistered(viewModel.Email) == false)
            {
                await _userService.Register(viewModel);
                var user = await _userService.GetUserEmail(viewModel.Email);
                var ActiveUser = new ActiveUserViewModel()
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    ActiveCode = user.ActivateCode
                };

                string body =_view.RenderToStringAsync("Active", ActiveUser);
                EmailSender.Send(ActiveUser.Email, "فعال سازی", body);
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("Email", "کاربری با این ایمیل قبلا ثبت نام کرده است");
            }
            return View();
        }


        [HttpGet("SignIn")]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost("SignIn"),ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var user = await _userService.GetUserEmail(viewModel.Email);
                var res = await _userService.LoginUser(viewModel);
                switch (res)
                {
                    case LoginResult.NotFound:
                        ModelState.AddModelError("Email", "کاربری با مشخصات وارد شده یافت نشد");
                        break;
                    case LoginResult.NotActive:
                        ModelState.AddModelError("Email", "کاربر مورد نظر فعال نشده است");
                        break;
                    case LoginResult.WrongPassword:
                        ModelState.AddModelError("Email", "کاربری با مشخصات وارد شده یافت نشد");
                        break;
                    case LoginResult.Succeeded:
                        List<Claim> claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                            new Claim(ClaimTypes.Email, user.Email),
                        };

                        ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync(principal, new AuthenticationProperties()
                        {
                            IsPersistent = viewModel.RememberMe
                        });
                        TempData["SuccessMessage"] = "خوش آمدید";
                        return RedirectToAction("Index","Home");
                }
            }
            return View();
        }

        [HttpGet("Active-account/{ActivateCode}")]
        public async Task<IActionResult> ActiveAccount(string ActivateCode)
        {
            var user = await _userService.GetUserByActivateCode(ActivateCode);
            if (user != null)
            {
                await _userService.GiveUserActiveRole(user);
                return RedirectToAction("Login");
            }

            return NotFound();
        }

        [HttpGet("Profile"),Authorize]
        public async Task<IActionResult> UserPanel()
        {
            var UserClaims = User.Claims.FirstOrDefault().Value;
            var user =await _userService.GetUserById(int.Parse(UserClaims));
            return View(user);
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
