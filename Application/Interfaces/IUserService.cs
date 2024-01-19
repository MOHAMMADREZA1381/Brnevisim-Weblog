using Application.ViewModel;
using Domain.ViewModels.User;

namespace Application.Interfaces;

public interface IUserService
{
    public Task<State> Register(RegisterViewModel viewModel);
    public Task<bool> IsEmailRegistered(string Email);
}