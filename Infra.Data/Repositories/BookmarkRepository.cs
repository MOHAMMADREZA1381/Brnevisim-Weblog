using Domain.IRepositories;
using Domain.Models;
using Domain.ViewModels.Bookmark;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class BookmarkRepository:IBookmarkRepository
{
    #region Context

    private readonly BlogContext _blogContext;
    public BookmarkRepository(BlogContext blogContext)
    {
        _blogContext = blogContext;
    }
    #endregion
    public async Task AddBookmark(Bookmark bookmark)
    {
       await _blogContext.AddAsync(bookmark);
       await _blogContext.SaveChangesAsync();
    }

    public async Task<FilterBookmarkViewModel> FiltertBookmarks(FilterBookmarkViewModel model)
    {
        var BookamrkList =  _blogContext.Bookmarks.Where(a => a.UserId == model.UserId).Include(a=>a.User).Include(a=>a.Content).Where(a => a.Content.IsDeleted == false).Include(a=>a.Content).ThenInclude(a => a.ContentViewsCollection).AsQueryable();
        await model.Paging(BookamrkList.Select(a => new BookmarkViewModel()
        {
            UserId = a.UserId,
            ContentId = a.ContentId,
            ImageBanner = a.Content.Banner,
            Title = a.Content.Title,
            ViewCount = a.Content.ContentViewsCollection.Count,
            UserName = a.User.UserName,
            CreateDate = a.Content.CreateDate
        }
        ));

        return model;
    }

    public async Task<bool> AddeBefor(int ContentId, int UserId)
    {
        return _blogContext.Bookmarks.Any(a => a.ContentId == ContentId && a.UserId == UserId);
    }
}