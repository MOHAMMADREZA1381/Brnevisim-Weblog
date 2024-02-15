using Domain.Models;
using Domain.ViewModels.Content;

namespace Domain.IRepositories;

public interface IContentRepository
{
    public Task CreateContentTask(Content content);
    public Task Edit(Content content);
    public Task<Content> GetContentById(int id);
    public Task<ICollection<Content>> AllContents();
    public Task<FilterContentViewModel> GetAllContentWithFilter(FilterContentViewModel model);

}