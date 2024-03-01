using Application.Interfaces;
using Domain.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Areas.AdminPanel.Controllers
{
    
    public class CategoryController : BaseController
    {
        #region Ctor
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        #endregion

        public async Task<IActionResult> Index()
        {
            var Categories = await _categoryService.GetAllCategories();
            return View(Categories);
        }
        [HttpGet]
        public async Task<IActionResult> AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.AddCategory(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            var Category = await _categoryService.GetCategoryById(id);
            var CategoryViewModel = new EditCategoryViewModel();
            CategoryViewModel.id = Category.id;
            CategoryViewModel.Name = Category.Name;
            return View(CategoryViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditCategory(EditCategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
              await  _categoryService.EditCategory(categoryViewModel);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
           await _categoryService.DeleteCategory(id);
           return RedirectToAction("Index");
        }
    }
}
