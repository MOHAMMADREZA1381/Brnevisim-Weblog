using Domain.Models;
using Domain.ViewModels.Content;

namespace Domain.IRepositories;

public interface IViewCountRepository
{
    public Task AddView(ContentViews contentViews);
    public Task<bool> IsAnyIp(string UserIp, int ContentId);
    public Task<int> ViewCount();
}