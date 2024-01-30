using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.IRepositories;
using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        #region Context
        private readonly BlogContext _context;
        public CategoryRepository(BlogContext context)
        {
            _context = context;
        }
        #endregion

        public async Task AddCategory(Category category)
        {
            _context.Add(category);
        }

        public async Task EditCategory(Category category)
        {
            _context.Update(category);
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var Category = _context.Categories.FirstOrDefault(a => a.id == id);
            return Category;

        }

        public async Task<List<Category>> GetAllCategories()
        {
            return _context.Categories.Where(a=>a.IsDeleted==false).ToList();
        }
    }
}
