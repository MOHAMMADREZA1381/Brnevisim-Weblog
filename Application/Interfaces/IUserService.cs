using Domain.Models;
using Domain.ViewModels.User;
namespace Application.Interfaces;

public interface IUserService
{
     Task<State> Register(RegisterViewModel viewModel);
     Task<bool> IsEmailRegistered(string Email);
     Task<User> GetUserByActivateCode(string ActivateCode);
     Task GiveUserActiveRole(User user);
     Task<UserViewModel> GetUserEmail(string Email);
     Task<LoginResult> LoginUser(LoginViewModel user);
     Task<UserViewModel> GetUserById(int id);
     Task<ICollection<UserViewModel>> GetUsers();
     Task DeleteUser(int id);
     Task EditUser(UserViewModel viewModel);
     Task<FilterUserViewModel> FilterUser(FilterUserViewModel filterUser);
     Task ForgotPassword(ForgotPasswordViewModel model);
     Task<bool> IsUserExistById(int Id);
     Task EditUserInfo(EditUserViewModel model,int id);

     Task ActiveMobile(int UserId,string Code);
}