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
        var BookamrkList =  _blogContext.Bookmarks.Where(a => a.UserId == model.UserId).Include(a=>a.User).Include(a=>a.Content).AsQueryable();
        await model.Paging(BookamrkList.Select(a => new BookmarkViewModel()
        {
            UserId = a.UserId,
            ContentId = a.ContentId,
            ImageBanner = a.Content.Banner,
            Title = a.Content.Title,
        }
        ));

        return model;
    }
}