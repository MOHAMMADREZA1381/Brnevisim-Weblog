using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.ViewCopmponents
{
    public class FooterLinkViewComponent : ViewComponent
    {
        private readonly IUseFulLinksService _useFulLinksService;

        public FooterLinkViewComponent(IUseFulLinksService useFulLinksService)
        {
            _useFulLinksService = useFulLinksService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var links = await _useFulLinksService.GetFooterLinks();
            return View("FooterLink",links);
        }
    }
}
