using Domain.Models;
using Domain.ViewModels.Content;

namespace Domain.IRepositories;

public interface IViewCountRepository
{
     Task AddView(ContentViews contentViews);
     Task<bool> IsAnyIp(string UserIp, int ContentId);
     Task<int> ViewCount();
     Task SaveAsync();
}