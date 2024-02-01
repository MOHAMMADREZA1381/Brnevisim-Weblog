using Application.Interfaces;
using Domain.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ApplicationUsersController : Controller
    {
        private readonly IUserService _userService;
        public ApplicationUsersController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index(FilterUserViewModel model)
        {
            
            var Users=await _userService.FilterUser(model);
            var UsersViewModel = new AdminUsersViewModel();
            UsersViewModel.FilterUserViewModel = Users;
            return View(UsersViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _userService.Register(model);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id != null)
            {
               await _userService.DeleteUser(id);
            }
            return RedirectToAction("Index");
        }
        [HttpGet("EditUser")]
        public async Task<IActionResult> EditUser(int id)
        {
            var User = await _userService.GetUserById(id);
            return View(User);
        }
        [HttpPost("EditUser")]
        public async Task<IActionResult> EditUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _userService.EditUser(model);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
