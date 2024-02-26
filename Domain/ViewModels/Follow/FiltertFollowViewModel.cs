using Domain.ViewModels.Paging.Pagination;

namespace Domain.ViewModels.Follow;

public class FiltertFollowViewModel:Pagination<FollowViewModel>
{
    public int page { get; set; }
    public int UserId { get; set; }
        public int? Count { get; set; }

}