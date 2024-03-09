using Application.Interfaces;
using Domain.IRepositories;
using Domain.Models;
using Domain.ViewModels.Admin.UseFulLinks;

namespace Application.Services;

public class UseFulLinksService:IUseFulLinksService
{
    #region Repositories

    private readonly IUseFulLinksRepository _service;

    public UseFulLinksService(IUseFulLinksRepository service)
    {
        _service = service;
    }

    #endregion
    public async Task AddLink(LinksViewModel LinkViewModel)
    {
        var link = new UseFulLink();
        link.Address= LinkViewModel.Address;
        link.Footer= LinkViewModel.Footer;
        link.LinkName= LinkViewModel.LinkName;
        await _service.AddLink(link);
    }

    public async Task Delete(int id)
    {
       await _service.Delete(id);
    }

    public async Task<List<UseFulLinkViewModel>> GetLinks()
    {
       var Links= await _service.GetLinks();
       var ListViewModel = new List<UseFulLinkViewModel>();
       foreach (var item in Links)
       {
           var linkViewModel = new UseFulLinkViewModel()
           {
               Address = item.Address,
               Footer = item.Footer,
               LinkName = item.LinkName,
               id = item.id
           };
           ListViewModel.Add(linkViewModel);
       }

       return ListViewModel;
    }

    public async Task<ICollection<LinksViewModel>> GetFooterLinks()
    {
      var links=  await _service.GetFooterLinks();
      var FooterLinks= new List<LinksViewModel>();
      foreach (var item in links)
      {
          var footerViewModel = new LinksViewModel()
          {
              Address = item.Address,
              Footer = item.Footer,
              LinkName = item.LinkName,
          };
          FooterLinks.Add(footerViewModel);
      }

      return FooterLinks;
    }

    public async Task<ICollection<LinksViewModel>> GetHeaderLinks()
    {
        var links = await _service.GetHeaderLinks();
        var HeaderLinks = new List<LinksViewModel>();
        foreach (var item in links)
        {
            var HeaderViewModel = new LinksViewModel()
            {
                Address = item.Address,
                Footer = item.Footer,
                LinkName = item.LinkName,
            };
            HeaderLinks.Add(HeaderViewModel);
        }

        return HeaderLinks;
    }
}