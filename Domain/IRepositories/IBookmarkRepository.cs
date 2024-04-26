using Domain.Models;
using Domain.ViewModels.Bookmark;

namespace Domain.IRepositories;

public interface IBookmarkRepository
{
     Task AddBookmark(Bookmark bookmark);
     Task<FilterBookmarkViewModel> FiltertBookmarks(FilterBookmarkViewModel model);
     Task<bool> AddeBefor(int ContentId, int UserId);
     Task RemoveFromBookmark(Bookmark model);
     Task<Bookmark> getBookmark(int ContentId, int UserId);
     Task SaveAsync();
}