using Domain.Models;
using Domain.ViewModels.Content;

namespace Application.Interfaces;

public interface IViewCountService
{
     Task AddView(ViewCountViewModel model);
     Task<bool> IsAnyIp(string UserIp,int ContentId);
     Task<int> ViewCount();
}