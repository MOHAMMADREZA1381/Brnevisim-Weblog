using Domain.Models;
using Domain.ViewModels.User;

namespace Domain.IRepositories;

public interface IUserRepository
{
    public Task Register(User user);
    public Task<bool> IsEmailAlreadyRegistered(string Email);
    public Task<User> GetUserByActivateCode(string ActivateCode);  
}