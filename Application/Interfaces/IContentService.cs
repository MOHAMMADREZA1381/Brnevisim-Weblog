using Domain.Models;
using Domain.ViewModels.Content;

namespace Application.Interfaces;

public interface IContentService
{
    public Task CreateContentTask(ContentViewModel content);
    public Task Edit(EditContentViewModel content);
    public Task<ContentViewModel> GetContentById(int id);
    public Task<ICollection<ContentViewModel>> AllContents();
    public Task<FilterContentViewModel> GetContentWithFilter(FilterContentViewModel model);
    public Task<EditContentViewModel> GetContentForEdit(int id);
    public Task<UserPanelContents> GetUserContents(UserPanelContents contents);
    public Task<State> DeletContent(int id, int UserId);
    public Task<bool> IsAnyContent(int id);
    public Task<ICollection<ContentViewModel>> GetUserContentsById(int UserId);
    public Task<IEnumerable<ContentViewModel>> MostViewContent();
    public Task<IEnumerable<ContentViewModel>> LastContent();
    public Task<IEnumerable<ContentViewModel>> getAllContents();
    public Task AddContentToGallery(List<int> ContentsId);
    public Task RemoveContentFromGallery(List<int> ContentsId);
    public Task<List<ContentViewModel>> GetContentForGallery();

}