using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.IRepositories;
using Domain.Models;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class ContentRepository:IContentRepository
    {
        #region Context
        private readonly BlogContext _context;
        public ContentRepository(BlogContext context)
        {
            _context = context;
        }
        #endregion
        public async Task CreateContenTask(Content content)
        {
            _context.Add(content);
            _context.SaveChanges();
        }

        public async Task Edit(Content content)
        {
            _context.Update(content);
            _context.SaveChanges();
        }

        public Task<Content> GetContentById(int id)
        {
            return _context.Contents.Include(a=>a.Category).Include(a=>a.User).FirstOrDefaultAsync(a=>a.id==id);
        }

        public async Task<ICollection<Content>> AllContents()
        {
          return _context.Contents.Include(a=>a.User).Include(a=>a.Category).Where(a=>a.IsDeleted==false).ToList();
        }
    }
}
