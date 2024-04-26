using Domain.Models;
using Domain.ViewModels.Admin.UseFulLinks;

namespace Application.Interfaces;

public interface IUseFulLinksService
{
     Task AddLink(LinksViewModel link);
     Task Delete(int id);
     Task<List<UseFulLinkViewModel>> GetLinks();
     Task<ICollection<LinksViewModel>> GetFooterLinks();
     Task<ICollection<LinksViewModel>> GetHeaderLinks();
}