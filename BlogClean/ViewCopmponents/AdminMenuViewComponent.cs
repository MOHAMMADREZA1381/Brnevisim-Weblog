using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BlogClean.ClaimsManager;
namespace BlogClean.ViewCopmponents
{
    public class AdminMenuViewComponent : ViewComponent
    {
        #region Services

        

        private readonly IUserService _userService;

        public AdminMenuViewComponent(IUserService userService)
        {
            _userService = userService;
        }
        #endregion
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int UserId = HttpContext.User.GetCurrentUserId();
            var User = await _userService.GetUserById(UserId);
            return View("AdminMenu",User);
        }
    }
}
