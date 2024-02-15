using Domain.ViewModels.Paging.Pagination;

namespace Domain.ViewModels.Content;

public class FilterContentViewModel:Pagination<ContentViewModel>
{
    public int page { get; set; }
    public string Title { get; set; }
}