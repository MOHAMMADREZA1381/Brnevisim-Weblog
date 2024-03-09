using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.ViewCopmponents
{
    public class HeaderLinkViewComponent : ViewComponent
    {
        private readonly IUseFulLinksService _useFulLinksService;

        public HeaderLinkViewComponent(IUseFulLinksService useFulLinksService)
        {
            _useFulLinksService = useFulLinksService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var links = await _useFulLinksService.GetHeaderLinks();
            return View("HeaderLink",links);
        }
    }
}
