using Domain.Models;
using Domain.ViewModels.Category;

namespace Application.Interfaces;

public interface ICategoryService
{
    public Task AddCategory(CategoryViewModel category);
    public Task EditCategory(EditCategoryViewModel category);
    public Task<CategoryViewModel> GetCategoryById(int id);
    public Task<List<CategoryViewModel>> GetAllCategories();
}