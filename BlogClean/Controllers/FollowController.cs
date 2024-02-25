using System.Security.Claims;
using Application.Interfaces;
using Domain.ViewModels.Follow;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Controllers
{
    public class FollowController : Controller
    {
        #region Services

        private readonly IFollowService _followService;
        private readonly IUserService _userService;
        public FollowController(IFollowService followService, IUserService userService)
        {
            _followService = followService;
            _userService = userService;
        }

        #endregion

        [Route("Following")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index(string? State)
        {
            TempData["MessageType"] = State;


            var Followings = await _followService.GetFollows(int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            return View(Followings);
        }

        [Route("Following")]
        [HttpPost]
        public IActionResult Index(int id)
        {
            return View();
        }


        [HttpGet]
        [Route("Followers")]
        public IActionResult Followers()
        {
            return View();
        }

        [HttpPost]
        [Route("Followers")]
        public async Task<IActionResult> Followers(int id)
        {
            return View();
        }

        [Authorize]
        [Route("Add-Follow")]
        public async Task<IActionResult> Follow(int id)
        {
            if (id==null||id==0)return PartialView("_NotFoundError");
            var UserExist = await _userService.IsUserExistById(id);
            if (UserExist==false) return PartialView("_NotFoundError");

            var UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            bool FollowedBefor = await _followService.FollowedBefor(UserId, id);

            if (UserExist==true && FollowedBefor==false)
            {
                var Follow = new FollowViewModel()
                {
                    UserId = UserId,
                    UserIdThatFollowed = id,
                };
                await _followService.AddFollow(Follow);
                return RedirectToAction("Index", new { id = UserId, State = "Success" });
            }
            return RedirectToAction("Index", new { id = UserId,State="Error" });
            
        }

        [Authorize]
        [Route("UnFollow")]
        public async Task<IActionResult> UnFollow(int FollowId,int UserIdWntUnFollow)
        {
            if (UserIdWntUnFollow == null || UserIdWntUnFollow == 0) return PartialView("_NotFoundError");
            if (FollowId == null || FollowId == 0) return PartialView("_NotFoundError");
            var UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            bool FollowedBefor = await _followService.FollowedBefor(UserId, UserIdWntUnFollow);
            if (FollowedBefor == false) return PartialView("_NotFoundError");

            if (FollowedBefor == true)
            {
                await _followService.RemoveFollow(FollowId);
                return RedirectToAction("Index", new { id = UserId, State = "Success" });
            }
            return RedirectToAction("Index", new { id = UserId, State = "Error" });
        }

        [Authorize]
        [Route("UnFollow-ByUsersId")]
        public async Task<IActionResult> UnByUsersIdFollow(int UserIdWntUnFollow)
        {
            if (UserIdWntUnFollow == null || UserIdWntUnFollow == 0) return PartialView("_NotFoundError");
            var UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            bool FollowedBefor = await _followService.FollowedBefor(UserId, UserIdWntUnFollow);
            if (FollowedBefor == false) return PartialView("_NotFoundError");

            if (FollowedBefor == true)
            {
                await _followService.RemoveByUsersId(UserId,UserIdWntUnFollow);
                return RedirectToAction("Index", new { id = UserId, State = "Success" });
            }
            return RedirectToAction("Index", new { id = UserId, State = "Error" });
        }


    }
}
