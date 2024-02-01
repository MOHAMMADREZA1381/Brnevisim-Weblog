using Application.ImageTools;
using Application.Interfaces;
using Application.Security;
using Domain.IRepositories;
using Domain.Models;
using Domain.ViewModels.User;
using Application.ImageTools.Common;
using Application.ImageTools;

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
            Password = PasswordHelper.EncodePasswordSha256(viewModel.Password),
            Email = viewModel.Email.ToLower().Trim(),
            ActivateCode = Guid.NewGuid().ToString("N"),
        };
        await _userRepository.Register(User);
        return State.Success;

    }


    public async Task<bool> IsEmailRegistered(string Email)
    {
        return await _userRepository.IsEmailAlreadyRegistered(Email);
    }

    public async Task<User> GetUserByActivateCode(string ActivateCode)
    {
        return await _userRepository.GetUserByActivateCode(ActivateCode);
    }

    public async Task GiveUserActiveRole(User user)
    {
        user.IsActive = true;
        user.ActivateCode = Guid.NewGuid().ToString("N");
        await _userRepository.GiveUserActiveRole(user);
    }

    public async Task<UserViewModel> GetUserEmail(string Email)
    {
        var User = await _userRepository.GetUserEmail(Email);
        var UserViewModel = new UserViewModel();
        if (User != null)
        {
            UserViewModel.id = User.Id;
            UserViewModel.Email = User.Email;
            UserViewModel.Phone = User.Phone;
            UserViewModel.picProfile = User.UserImg;
            UserViewModel.UserName = User.UserName;
            UserViewModel.ActivateCode= User.ActivateCode;
        }
        return UserViewModel;
    }

    public async Task<LoginResult> LoginUser(LoginViewModel viewModel)
    {
        var PasswordHashed = PasswordHelper.EncodePasswordSha256(viewModel.Password);
        var user = await _userRepository.GetUserEmail(viewModel.Email.ToLower().Trim());
        if (user == null) return LoginResult.NotFound;
        if (user.IsActive == false) return LoginResult.NotActive;
        if (user.Password != PasswordHashed) return LoginResult.WrongPassword;

        return LoginResult.Succeeded;
    }

    public async Task<UserViewModel> GetUserById(int id)
    {
        var user = await _userRepository.GetUserById(id);
        var UserViewModel = new UserViewModel()
        {
            Email = user.Email,
            UserName = user.UserName,
            Phone = user.Phone,
            picProfile = user.UserImg,
            id = user.Id,
            IsAdmin = user.IsAdmin,
            IsDeleted = user.IsDelete,
            ActivateCode = user.ActivateCode,
            IsActive = user.IsActive,
        };
        return UserViewModel;
    }

    public async Task<ICollection<UserViewModel>> GetUsers()
    {
        var UserListViewModel = new List<UserViewModel>();
        var Users = await _userRepository.GetUserList();
        foreach (var item in Users)
        {
            var UserViewModel = new UserViewModel()
            {
                Email = item.Email,
                Phone = item.Phone,
                picProfile = item.UserImg,
                UserName = item.UserName,
                id = item.Id,
                IsAdmin = item.IsAdmin
            };
            UserListViewModel.Add(UserViewModel);
        }
        return UserListViewModel;
    }

    public async Task DeleteUser(int id)
    {
        var user = await _userRepository.GetUserById(id);
        user.IsDelete = true;
        await _userRepository.EditUser(user);
    }

    public async Task EditUser(UserViewModel viewModel)
    {
        var User = await _userRepository.GetUserById(viewModel.id);
        if (viewModel.UserImg?.Length > 0)
        { 
            var galleryImage = "";
            galleryImage = Guid.NewGuid().ToString("N") + Path.GetExtension(viewModel.UserImg.FileName);
            viewModel.UserImg.AddImageToServer(galleryImage, PathExtensions.UserAvatarOrginServer, 300, 300, PathExtensions.UserAvatarThumbServer);
            User.UserImg = galleryImage;
        }
        User.Email = viewModel.Email;
        User.UserName = viewModel.UserName;
        User.Phone = viewModel.Phone;
        User.IsDelete = viewModel.IsDeleted;
        User.IsAdmin = viewModel.IsAdmin;
        User.IsActive = viewModel.IsActive;
        await _userRepository.EditUser(User);
    }

    public async Task<FilterUserViewModel> FilterUser(FilterUserViewModel filterUser)
    {
       return await _userRepository.GetFilterUserViewModel(filterUser);
    }
}