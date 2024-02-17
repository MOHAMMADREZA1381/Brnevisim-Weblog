using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using Application.Interfaces;
using Application.SenderEmail;
using Domain.ViewModels.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Controllers
{
    public class AccountController : Controller
    {
        #region Service
        private readonly IUserService _userService;
        private readonly IRenderService _Render;
        public AccountController(IUserService userService, IRenderService Render)
        {
            _userService = userService;
            _Render = Render;
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
                object UserModel = await _userService.GetUserByActivateCode(user.ActivateCode);

                string Body = _Render.RenderToStringAsync("_ActiveMail", UserModel);
                EmailSender.Send(user.Email, "فعال سازی", Body);
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
        [HttpPost("SignIn"), ValidateAntiForgeryToken]
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
                        return RedirectToAction("Index", "Home");
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

        [HttpGet("Profile"), Authorize]
        public async Task<IActionResult> UserPanel()
        {
            var UserClaims = User.Claims.FirstOrDefault().Value;
            var user = await _userService.GetUserById(int.Parse(UserClaims));
            return View(user);
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }







        [HttpGet("Forgot-Password")]
        public async Task<IActionResult> ForgotPassword()
        {

            return View();
        }

        [HttpPost("Forgot-Password")]
        public async Task<IActionResult> ForgotPassword(EmailViewModel viewModel)
        {
            if (viewModel.Email == null)
            {
                ModelState.AddModelError("email", "لطفا ایمیلی را وارد کنید");

            }

            var User = await _userService.IsEmailRegistered(viewModel.Email);
            if (User == true)
            {
                object UserInfo = await _userService.GetUserEmail(viewModel.Email);
                string Body = _Render.RenderToStringAsync("_ForgotPasswordMail", UserInfo);
                EmailSender.Send(viewModel.Email, "تغیر رمز عبور", Body);
                ModelState.AddModelError("email", "اگر ایمیل وارد شده صحیح باشد یک لینک برای تغیر رمز عبور برای شما ارسال شده است");

            }
            return View();
        }




        [HttpGet("Change-Password/{ActivateCode}")]
        public async Task<IActionResult> ChangePassword(string ActivateCode)
        {
            if (ActivateCode == null) return RedirectToAction("ForgotPassword");

            var user = await _userService.GetUserByActivateCode(ActivateCode);
            if (user == null) return RedirectToAction("ForgotPassword");

            var forgotPassword = new ForgotPasswordViewModel();
            forgotPassword.ActivateCode = user.ActivateCode;
            return View(forgotPassword);
        }

        [HttpPost("Change-Password/{ActivateCode}")]
        public async Task<IActionResult> ChangePassword(ForgotPasswordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _userService.ForgotPassword(viewModel);
                return RedirectToAction("Login");
            }

            return View();
        }





    }
}
