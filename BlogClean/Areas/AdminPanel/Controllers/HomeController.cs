using AngleSharp.Attributes;
using Application.Interfaces;
using BlogClean.HttpSecurity;
using Domain.ViewModels.Admin.UseFulLinks;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Areas.AdminPanel.Controllers
{
   
    public class HomeController : BaseController
    {
        #region Services

        

        private readonly IUseFulLinksService _useFulLinksService;

        public HomeController(IUseFulLinksService useFulLinksService)
        {
            _useFulLinksService = useFulLinksService;
        }
        #endregion
      
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddDynamicLink()
        {
            var MangeLinks = new ManageLinksViewModel();
            var Links= await _useFulLinksService.GetLinks();
            MangeLinks.UseFulLinkViewModels = Links;
            return View(MangeLinks);
        }


        [HttpPost]
        public async Task<IActionResult> AddDynamicLink(LinksViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _useFulLinksService.AddLink(model);
            }
            var Manage = new ManageLinksViewModel();
            Manage.UseFulLinkViewModels= await _useFulLinksService.GetLinks();
            return View(Manage);
        }

    }
}
