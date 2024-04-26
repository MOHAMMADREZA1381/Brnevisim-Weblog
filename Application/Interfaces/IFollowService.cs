
using Domain.Models;
using Domain.ViewModels.Follow;

namespace Application.Interfaces;

public interface IFollowService
{
     Task AddFollow(FollowViewModel followViewModel);
     Task RemoveFollow(int id);
     Task RemoveByUsersId(int userId, int UserIdFollowed);
     Task<ICollection<FollowViewModel>> GetFollows(int UserId);
     Task<ICollection<FollowViewModel>> GetFollowers(int UserId);
     Task<bool> FollowedBefor(int UserId, int UserIdWntToFollow);
     Task<Following> GetFollowByIdTask(int Id);
     Task<Following> GetFollowByUsersId(int userId, int UserIdFollowed);

     Task<FiltertFollowViewModel> GetFilterFollowViewModel(FiltertFollowViewModel model);
     Task<FiltertFollowViewModel> GetFilterFollowersViewModel(FiltertFollowViewModel model);


}