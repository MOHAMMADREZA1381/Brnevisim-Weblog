using Domain.Models;
using Domain.ViewModels.Follow;

namespace Domain.IRepositories;

public interface IFollowRepository
{
     Task AddFollow(Following following);
     Task RemoveFollow(Following following);
     Task<ICollection<Following>> GetFollows(int UserId);
     Task<ICollection<Following>> GetFollowers(int UserId);
     Task<bool>FollowedBefor(int UserId,int UserIdWntToFollow);
     Task<Following> GetFollowing(int id);
     Task<Following> GetFollowByUsersId(int UserId,int UserIdFollowed);
     Task<FiltertFollowViewModel> GetFilterFollowViewModel(FiltertFollowViewModel model);
     Task<FiltertFollowViewModel> GetFilterFollowersViewModel(FiltertFollowViewModel model);
     Task SaveAsync();

}