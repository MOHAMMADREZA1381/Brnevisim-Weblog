using Application.Interfaces;
using Domain.ViewModels.Content;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace BlogClean.Controllers
{
    [Authorize]
    public class ContentController : Controller
    {
        #region Services
        private readonly IContentService _contentService;
        private readonly ICategoryService _categoryService;

        public ContentController(IContentService contentService,ICategoryService categoryService)
        {
            _contentService = contentService;
            _categoryService = categoryService;
        }
        #endregion

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet("Add-Content")]
        public async Task<IActionResult> CreateContent()
        {
            var ContentViewModel = new ContentViewModel();
            ContentViewModel.CategoryViewModels =await _categoryService.GetAllCategories();
            ContentViewModel.UserId =int.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            return View(ContentViewModel);
        }

        [HttpPost("Add-Content")]
        public async Task<IActionResult> CreateContent(ContentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _contentService.CreateContenTask(viewModel);
               return RedirectToAction("Index");
            }

            viewModel.CategoryViewModels=await _categoryService.GetAllCategories();
            viewModel.UserId = int.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(viewModel);
        }
    }
}
