using Domain.ViewModels.User;

namespace Domain.ViewModels.Admin;

public class UserInfoViewModel
{
    public UserViewModel UserViewModel { get; set; }
    public decimal BalanceSms { get; set; }
}