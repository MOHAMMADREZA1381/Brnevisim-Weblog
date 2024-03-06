using AngleSharp.Attributes;
using Application.Interfaces;
using BlogClean.HttpSecurity;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Areas.AdminPanel.Controllers
{
   
    public class HomeController : BaseController
    {
        private readonly ISmsService _sms;
        public HomeController(ISmsService sms)
        {
            _sms = sms;
        }
        public async Task<IActionResult> Index()
        {
           

            return View();
        }
    }
}
