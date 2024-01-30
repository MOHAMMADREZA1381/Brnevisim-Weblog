using Application.Interfaces;
using Domain.IRepositories;
using Domain.Models;
using Domain.ViewModels.Category;
using Microsoft.VisualBasic;
using System.Collections;

namespace Application.Services;

public class CategoryService:ICategoryService
{
    #region Repository
    private readonly  ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    #endregion

    public async Task AddCategory(CategoryViewModel category)
    {
        var Category = new Category();
        Category.Name = category.Name;

        await _categoryRepository.AddCategory(Category);
    }

    public async Task EditCategory(EditCategoryViewModel category)
    {
        var Category=new Category();
        Category.Name = category.Name;
        Category.IsDeleted=category.IsDeleted;
        await _categoryRepository.EditCategory(Category);
    }

    public async Task<CategoryViewModel> GetCategoryById(int id)
    {
        var Category = await _categoryRepository.GetCategoryById(id);
        var CategoryVieModel = new CategoryViewModel()
        {
            Name = Category.Name,
            id = Category.id,
        };
        return CategoryVieModel;
    }

    public async Task<List<CategoryViewModel>> GetAllCategories()
    {
        var Categories=await _categoryRepository.GetAllCategories();
        var CategoriesViewModel = new List<CategoryViewModel>();

        foreach (var Item in Categories)
        {
            var ViewModel = new CategoryViewModel();
            ViewModel.Name = Item.Name;
            ViewModel.id=Item.id;
            CategoriesViewModel.Add(ViewModel);
        }
        return CategoriesViewModel;
    }
}