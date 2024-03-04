
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
                .Include(a => a.CaseMessages.OrderByDescending(a=>a.CreateDate).Where(a=>a.IsDelete==false))
                .ThenInclude(a => a.Messages.Where(a=>a.IsDelete==false))
                .ThenInclude(a => a.User)
                .Include(a=>a.ContentViewsCollection)
                .FirstOrDefaultAsync(a => a.id == id);
            return Conetnt;
        }

        public async Task<ICollection<Content>> AllContents()
        {
            return _context.Contents.Include(a => a.User).Include(a => a.Category).Where(a => a.IsDeleted == false).Where(a=>a.User.IsDelete==false).Include(a=>a.ContentViewsCollection).ToList();
        }

        public async Task<FilterContentViewModel> GetAllContentWithFilter(FilterContentViewModel model)
        {
            var Contents = _context.Contents.Where(a => a.IsDeleted == false && a.User.IsDelete==false).AsQueryable();
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
                ViewCount = a.ContentViewsCollection.Count,
                Title = a.Title,
            }
            ));
            return model;
        }

        public async Task<bool> IsAnyContentByIdTask(int id)
        {
            return _context.Contents.Any(a => a.id == id);
        }

        public async Task<UserPanelContents> GetUserContent(UserPanelContents contents)
        {
            var Contents =  _context.Contents.Where(a => a.UserId == contents.UserId && a.IsDeleted==false).AsQueryable();
            await contents.Paging(Contents.Select(a => new ContentViewModel()
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
                    ViewCount = a.ContentViewsCollection.Count,
                    Title = a.Title,
                }
            ));
            return contents;
        }

        public async Task<ICollection<Content>> GetContentsByUserId(int userId)
        {
            var Contents = await _context.Contents.Where(a => a.UserId == userId && a.IsDeleted==false).Include(a=>a.User).Include(a=>a.ContentViewsCollection).ToListAsync();
            return Contents;
        }
    }
}
