using Application.Interfaces;
using Domain.IRepositories;
using Domain.Models;
using Domain.ViewModels.Bookmark;

namespace Application.Services;

public class BookmarkService:IBookmarkService
{
    #region Repository
    private readonly IBookmarkRepository _bookmarkRepository;
    public BookmarkService(IBookmarkRepository bookmarkRepository)
    {
        _bookmarkRepository = bookmarkRepository;
    }
    #endregion
    public async Task AddBookmark(BookmarkViewModel model)
    {
        var Bookmark = new Bookmark()
        {
            UserId = model.UserId,
            ContentId = model.ContentId,

        };
        await _bookmarkRepository.AddBookmark(Bookmark);
    }

    public async Task<FilterBookmarkViewModel> GettBookmarkList(FilterBookmarkViewModel viewModel)
    {
       return await _bookmarkRepository.FiltertBookmarks(viewModel);
    }

    public async Task<bool> AddBefor(int ContentId, int UserId)
    {
        return await _bookmarkRepository.AddeBefor(ContentId, UserId);
    }
}