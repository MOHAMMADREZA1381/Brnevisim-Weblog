using Domain.ViewModels.Paging.Pagination;

namespace Domain.ViewModels.Content;

public class UserPanelContents:Pagination<ContentViewModel>
{
    public int page { get; set; }
    public int UserId { get; set; }
}