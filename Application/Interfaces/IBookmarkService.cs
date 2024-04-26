using Domain.Models;
using Domain.ViewModels.Bookmark;

namespace Application.Interfaces;

public interface IBookmarkService
{
     Task AddBookmark(BookmarkViewModel model);
     Task<FilterBookmarkViewModel> GettBookmarkList(FilterBookmarkViewModel viewModel);
     Task<bool> AddBefor(int ContentId, int UserId);
     Task RemoveFromBookmark(Bookmark model);
     Task<Bookmark> getBookmark(int ContentId, int UserId);

}