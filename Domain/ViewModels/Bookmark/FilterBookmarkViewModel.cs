using Domain.ViewModels.Paging.Pagination;
namespace Domain.ViewModels.Bookmark;

public class FilterBookmarkViewModel:Pagination<Bookmark.BookmarkViewModel>
{
    public int page { get; set; }
    public int UserId { get; set; }
}