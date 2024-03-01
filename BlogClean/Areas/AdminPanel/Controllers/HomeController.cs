using AngleSharp.Attributes;
using BlogClean.HttpSecurity;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Areas.AdminPanel.Controllers
{
   
    public class HomeController : BaseController
    {
    
        public IActionResult Index()
        {
            return View();
        }
    }
}
