
using Domain.ViewModels.Follow;

namespace Application.Interfaces;

public interface IFollowService
{
    public Task AddFollow(FollowViewModel followViewModel);
    public Task RemoveFollow(FollowViewModel viewModel);
    public Task<ICollection<FollowViewModel>> GetFollows(int UserId);
    public Task<ICollection<FollowViewModel>> GetFollowers(int UserId);
    public Task<bool> FollowedBefor(int UserId, int UserIdWntToFollow);
}