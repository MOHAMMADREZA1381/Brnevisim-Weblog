using Domain.Models;
using Domain.ViewModels.Category;

namespace Application.Interfaces;

public interface ICategoryService
{
    public Task AddCategory(AddCategoryViewModel category);
    public Task EditCategory(EditCategoryViewModel category);
    public Task<CategoryViewModel> GetCategoryViewModelById(int id);
    public Task<List<CategoryViewModel>> GetAllCategories();
    public Task<Category> GetCategoryById(int id);
    public Task DeleteCategory(int id);
}