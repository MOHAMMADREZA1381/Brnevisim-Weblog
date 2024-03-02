using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.ViewCopmponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryMenuViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int Count)
        {

            var CategoryList=await _categoryService.GetAllCategories();
        
            return View("CategoryMenu",CategoryList.Skip(Count).Take(7));
        }
    }
}
