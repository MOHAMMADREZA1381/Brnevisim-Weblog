using Domain.Models;

namespace Domain.IRepositories;

public interface IContentRepository
{
    public Task CreateContenTask(Content content);
    public Task Edit(Content content);
    public Task<Content> GetContentById(int id);
    public Task<ICollection<Content>> AllContents();

}