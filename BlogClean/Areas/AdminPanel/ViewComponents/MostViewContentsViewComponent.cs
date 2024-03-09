using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Areas.AdminPanel.ViewComponents
{
    public class MostViewContentsViewComponent : ViewComponent
    {
        private readonly IContentService _contentService;

        public MostViewContentsViewComponent(IContentService contentService)
        {
            _contentService = contentService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Content = await _contentService.MostViewContent();

            return View("MostViewContents",Content);
        }
    }
}
