using Application.Interfaces;
using Domain.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Areas.AdminPanel.ViewComponents
{
    public class UserInfoViewComponent : ViewComponent
    {
        #region Services

        

        private readonly ISmsService _msService;
        private readonly IUserService _userService;

        public UserInfoViewComponent(ISmsService msService, IUserService userService)
        {
            _msService = msService;
            _userService = userService;
        }
        #endregion
        
        public async Task<IViewComponentResult> InvokeAsync(int UserId)
        {
          
            var AdminInfo = new UserInfoViewModel();
            AdminInfo.UserViewModel = await _userService.GetUserById(UserId);
            AdminInfo.BalanceSms = await _msService.GetBalnce();

            return View("UserInfo",AdminInfo);
        }
    }
}
