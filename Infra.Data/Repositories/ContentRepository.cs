
using Domain.IRepositories;
using Domain.Models;
using Domain.ViewModels.Content;
using Domain.ViewModels.Message;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class ContentRepository : IContentRepository
    {
        #region Context
        private readonly BlogContext _context;
        public ContentRepository(BlogContext context)
        {
            _context = context;
        }
        #endregion
        public async Task CreateContentTask(Content content)
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
            var Conetnt = _context.Contents.Include(a => a.Category)
                .Include(a => a.User)
                .Include(a => a.CaseMessages)
                .ThenInclude(a => a.Messages)
                .ThenInclude(a => a.User)
                .Include(a => a.CaseMessages)
                .ThenInclude(a => a.Messages).ThenInclude(a => a.User)
                .FirstOrDefaultAsync(a => a.id == id);
            return Conetnt;
        }

        public async Task<ICollection<Content>> AllContents()
        {
            return _context.Contents.Include(a => a.User).Include(a => a.Category).Where(a => a.IsDeleted == false).ToList();
        }

        public async Task<FilterContentViewModel> GetAllContentWithFilter(FilterContentViewModel model)
        {
            var Contents = _context.Contents.Where(a => a.IsDeleted == false).AsQueryable();
            if (!string.IsNullOrEmpty(model.Title))
            {
                Contents = Contents.Where(a => EF.Functions.Like(a.Title, $"%{model.Title}%"));
            }

            await model.Paging(Contents.Select(a => new ContentViewModel()
            {
                UserName = a.User.UserName,
                id = a.id,
                BannerName = a.Banner,
                UserId = a.UserId,
                CategoryId = a.CategoryId,
                SubTitle = a.SubTitle,
                ContentText = a.ContentText,
                CreateDate = a.CreateDate,
                Tag = a.Tag,
                ViewCount = a.ViewCount,
                Title = a.Title,
            }
            ));
            return model;
        }

        public async Task<bool> IsAnyContentByIdTask(int id)
        {
            return _context.Contents.Any(a => a.id == id);
        }

    }
}
