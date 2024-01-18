using Domain.Models;
using Domain.ViewModels.User;

namespace Domain.IRepositories;

public interface IUserRepository
{
    public Task Register(User user);
}