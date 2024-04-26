using Domain.Models;
using Domain.ViewModels.Content;

namespace Application.Interfaces;

public interface IContentService
{
     Task CreateContentTask(ContentViewModel content);
     Task Edit(EditContentViewModel content);
     Task<ContentViewModel> GetContentById(int id);
     Task<ICollection<ContentViewModel>> AllContents();
     Task<FilterContentViewModel> GetContentWithFilter(FilterContentViewModel model);
     Task<EditContentViewModel> GetContentForEdit(int id);
     Task<UserPanelContents> GetUserContents(UserPanelContents contents);
     Task<State> DeletContent(int id, int UserId);
     Task<bool> IsAnyContent(int id);
     Task<ICollection<ContentViewModel>> GetUserContentsById(int UserId);
     Task<IEnumerable<ContentViewModel>> MostViewContent();
     Task<IEnumerable<ContentViewModel>> LastContent();
     Task<IEnumerable<ContentViewModel>> getAllContents();
     Task AddContentToGallery(List<int> ContentsId);
     Task RemoveContentFromGallery(List<int> ContentsId);
     Task<List<ContentViewModel>> GetContentForGallery();

}