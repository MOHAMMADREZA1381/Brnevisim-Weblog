using Domain.Models;

namespace Domain.IRepositories;

public interface IUseFulLinksRepository
{
    public Task AddLink(UseFulLink link);
    public Task Delete(int id);
    public Task<UseFulLink> Get(int id);
    public Task<ICollection<UseFulLink>> GetLinks();
    public Task<ICollection<UseFulLink>> GetFooterLinks();
    public Task<ICollection<UseFulLink>> GetHeaderLinks();


}