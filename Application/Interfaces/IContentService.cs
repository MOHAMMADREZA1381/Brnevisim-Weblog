using Domain.Models;
using Domain.ViewModels.Content;

namespace Application.Interfaces;

public interface IContentService
{
    public Task CreateContentTask(ContentViewModel content);
    public Task Edit(ContentViewModel content);
    public Task<ContentViewModel> GetContentById(int id);
    public Task<ICollection<ContentViewModel>> AllContents();
    public Task<FilterContentViewModel> GetContentWithFilter(FilterContentViewModel model);
}