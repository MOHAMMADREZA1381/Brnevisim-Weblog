using Domain.Models;
using Domain.ViewModels.Content;

namespace Domain.IRepositories;

public interface IContentRepository
{
     Task CreateContentTask(Content content);
     Task Edit(Content content);
     Task<Content> GetContentById(int id);
     Task<ICollection<Content>> AllContents();
     Task<FilterContentViewModel> GetAllContentWithFilter(FilterContentViewModel model);
     Task<bool> IsAnyContentByIdTask(int id);
     Task<UserPanelContents> GetUserContent(UserPanelContents contents);
     Task<ICollection<Content>> GetContentsByUserId(int userId);
    Task<ICollection<Content>> GetContentForGaller();
    Task SaveAsync();

}