using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Application.Interfaces;
using Domain.ViewModels.Home;

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
    

        public async Task<IActionResult> Index()
        {
            var HomeViewModel = new HomeViewModel();
            HomeViewModel.MostViewContent = await _contentService.MostViewContent();
            HomeViewModel.LastContent=await _contentService.LastContent();
            HomeViewModel.AllContent = await _contentService.getAllContents();
            return View(HomeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    
    }
}
