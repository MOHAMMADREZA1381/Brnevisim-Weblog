using Domain.Models;

namespace Domain.IRepositories;

public interface IFollowRepository
{
    public Task AddFollow(Following following);
    public Task RemoveFollow(Following following);
    public Task<ICollection<Following>> GetFollows(int UserId);
    public Task<ICollection<Following>> GetFollowers(int UserId);
    public Task<bool>FollowedBefor(int UserId,int UserIdWntToFollow);
    public Task<Following> GetFollowing(int id);
    public Task<Following> GetFollowByUsersId(int UserId,int UserIdFollowed);
}