using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Application.Interfaces;

namespace BlogClean.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContentService _contentService;
        private readonly ICategoryService _categoryService;

        public HomeController(ILogger<HomeController> logger, IContentService contentService, ICategoryService categoryService)
        {
            _logger = logger;
            _contentService = contentService;
            _categoryService = categoryService;
        }
    

        public IActionResult Index()
        {
            

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    
    }
}
