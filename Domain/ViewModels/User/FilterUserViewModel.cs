
using Domain.ViewModels.Paging.Pagination;

namespace Domain.ViewModels.User
{
    public class FilterUserViewModel:Pagination<UserViewModel>
    {
        public int Page { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }=false;
        public bool IsActive { get; set; } = false;
    }
}
