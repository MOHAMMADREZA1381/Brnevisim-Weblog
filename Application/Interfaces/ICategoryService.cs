using Domain.Models;
using Domain.ViewModels.Category;

namespace Application.Interfaces;

public interface ICategoryService
{
     Task AddCategory(AddCategoryViewModel category);
     Task EditCategory(EditCategoryViewModel category);
     Task<CategoryViewModel> GetCategoryViewModelById(int id);
     Task<List<CategoryViewModel>> GetAllCategories();
     Task<Category> GetCategoryById(int id);
     Task DeleteCategory(int id);
}