using Domain.Models;
using Domain.ViewModels.User;

namespace Domain.IRepositories;

public interface IUserRepository
{
    public Task Register(User user);
    public Task<bool> IsEmailAlreadyRegistered(string Email);
    public Task<User> GetUserByActivateCode(string ActivateCode);
    public Task GiveUserActiveRole(User user);
    public Task<User> GetUserEmail(string Email);
    public Task<User> GetUserById(int id);
    public Task<ICollection<User>> GetUserList();
    public Task EditUser(User user);
    public Task<FilterUserViewModel> GetFilterUserViewModel(FilterUserViewModel filterUserViewModel);
    public Task<bool> IsUserExistById(int Id);
    public Task SaveAsync();

}