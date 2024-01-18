﻿using Application.Interfaces;
using Application.ViewModel;
using Domain.IRepositories;
using Domain.Models;
using Domain.ViewModels.User;

namespace Application.Services;

public class UserService : IUserService
{
    #region Repository
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    #endregion

    public async Task<State> Register(RegisterViewModel viewModel)
    {
        if (viewModel == null) { return State.Failed; }

        var User = new User
        {
            UserName = viewModel.UserName,
            Password = viewModel.Password,
            Email = viewModel.Email,
            ActivateCode = Guid.NewGuid().ToString("N"),
        };
        await _userRepository.Register(User);
        return State.Success;

    }
}