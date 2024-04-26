using Domain.Models;

namespace Domain.IRepositories;

public interface IUseFulLinksRepository
{
     Task AddLink(UseFulLink link);
     Task Delete(int id);
     Task<UseFulLink> Get(int id);
     Task<ICollection<UseFulLink>> GetLinks();
     Task<ICollection<UseFulLink>> GetFooterLinks();
     Task<ICollection<UseFulLink>> GetHeaderLinks();
     Task SaveAsync();


}