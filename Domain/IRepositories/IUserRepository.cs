using Domain.Models;
using Domain.ViewModels.User;

namespace Domain.IRepositories;

public interface IUserRepository
{
     Task Register(User user);
     Task<bool> IsEmailAlreadyRegistered(string Email);
     Task<User> GetUserByActivateCode(string ActivateCode);
     Task GiveUserActiveRole(User user);
     Task<User> GetUserEmail(string Email);
     Task<User> GetUserById(int id);
     Task<ICollection<User>> GetUserList();
     Task EditUser(User user);
     Task<FilterUserViewModel> GetFilterUserViewModel(FilterUserViewModel filterUserViewModel);
     Task<bool> IsUserExistById(int Id);
     Task SaveAsync();

}