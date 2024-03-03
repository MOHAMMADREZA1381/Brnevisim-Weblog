using Domain.ViewModels.Content;

namespace Domain.ViewModels.User;

public class UserPanelViewModel
{
    public UserViewModel UserViewModel { get; set; }
    public ICollection<ContentViewModel> ContentViewModels { get; set; }

}