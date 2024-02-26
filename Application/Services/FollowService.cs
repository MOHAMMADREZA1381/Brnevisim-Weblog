using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.IRepositories;
using Domain.Models;
using Domain.ViewModels.Follow;

namespace Application.Services
{
    public class FollowService:IFollowService
    {
        #region Repository

        

        private readonly IFollowRepository _followRepository;
        private readonly IUserService _userService;
    

        public FollowService(IFollowRepository followRepository,IUserService userService)
        {
            _followRepository = followRepository;
            _userService= userService;
        }
        #endregion

        public async Task AddFollow(FollowViewModel followViewModel)
        {
            bool FollowedBefor = await this.FollowedBefor(followViewModel.UserId, followViewModel.UserIdThatFollowed);
            if (FollowedBefor == false)
            {
                var UserWntFollow = await _userService.GetUserById(followViewModel.UserIdThatFollowed);
                var FollowUser = new Following()
                {
                    UserId = followViewModel.UserId,
                    UserIdThatFollowed = followViewModel.UserIdThatFollowed,
                    UserNameThatFollowed = UserWntFollow.UserName,
                    
                };

                await _followRepository.AddFollow(FollowUser);
            }
        }

        public async Task RemoveFollow(int id)
        {
            var Model = await this.GetFollowByIdTask(id);
            await _followRepository.RemoveFollow(Model);
            
        }

        public async Task RemoveByUsersId(int userId, int UserIdFollowed)
        {
            var GetFollowEntity= await GetFollowByUsersId(userId, UserIdFollowed);
            await _followRepository.RemoveFollow(GetFollowEntity);
        }

        public async Task<ICollection<FollowViewModel>> GetFollows(int UserId)
        {
          var Followed=await _followRepository.GetFollows(UserId);
          var FollowedList = new List<FollowViewModel>();
          foreach (var itemFollowing in Followed)
          {
              var FollowedViewModel = new FollowViewModel()
              {
                  Id = itemFollowing.Id,
                  UserId = itemFollowing.UserId,
                  UserIdThatFollowed = itemFollowing.UserIdThatFollowed,
                  UserNameThatFollowed = itemFollowing.UserNameThatFollowed,
                  UserProfile = itemFollowing.User.UserImg,
              };
              FollowedList.Add(FollowedViewModel);
          }

          return FollowedList;
        }

        public async Task<ICollection<FollowViewModel>> GetFollowers(int UserId)
        {
            var Followed = await _followRepository.GetFollowers(UserId);
            var FollowedList = new List<FollowViewModel>();
            foreach (var itemFollowing in Followed)
            {
                var FollowedViewModel = new FollowViewModel()
                {
                    Id = itemFollowing.Id,
                    UserId = itemFollowing.UserId,
                    UserIdThatFollowed = itemFollowing.UserIdThatFollowed,
                    UserNameThatFollowed = itemFollowing.UserNameThatFollowed,
                    UserProfile = itemFollowing.User.UserImg,
                };
                FollowedList.Add(FollowedViewModel);
            }

            return FollowedList;
        }

        public async Task<bool> FollowedBefor(int UserId, int UserIdWntToFollow)
        {
            return await _followRepository.FollowedBefor(UserId, UserIdWntToFollow);
        }

        public async Task<Following> GetFollowByIdTask(int Id)
        {
            return await _followRepository.GetFollowing(Id);
        }

        public async Task<Following> GetFollowByUsersId(int userId, int UserIdFollowed)
        {
            return await _followRepository.GetFollowByUsersId(userId, UserIdFollowed);
        }

        public async Task<FiltertFollowViewModel> GetFilterFollowViewModel(FiltertFollowViewModel model)
        {
           var list= await _followRepository.GetFilterFollowViewModel(model);
           return list;
        }

        public async Task<FiltertFollowViewModel> GetFilterFollowersViewModel(FiltertFollowViewModel model)
        {
           return await _followRepository.GetFilterFollowersViewModel(model);
        }
    }
}
