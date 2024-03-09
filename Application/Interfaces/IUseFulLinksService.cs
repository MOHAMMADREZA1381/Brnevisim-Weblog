using Domain.Models;
using Domain.ViewModels.Admin.UseFulLinks;

namespace Application.Interfaces;

public interface IUseFulLinksService
{
    public Task AddLink(LinksViewModel link);
    public Task Delete(int id);
    public Task<List<UseFulLinkViewModel>> GetLinks();
    public Task<ICollection<LinksViewModel>> GetFooterLinks();
    public Task<ICollection<LinksViewModel>> GetHeaderLinks();
}