using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> AddCategory()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditCategory()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> EditCategory()
        //{
        //    return View();
        //}
    }
}
