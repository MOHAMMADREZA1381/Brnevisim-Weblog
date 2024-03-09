using Domain.Models;
using Domain.ViewModels.Content;

namespace Application.Interfaces;

public interface IViewCountService
{
    public Task AddView(ViewCountViewModel model);
    public Task<bool> IsAnyIp(string UserIp,int ContentId);
    public Task<int> ViewCount();
}