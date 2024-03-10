using Application.Interfaces;
using BlogClean.ClaimsManager;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.ViewCopmponents
{
    public class ContentOwnerViewComponent : ViewComponent
    {
        private readonly IContentService _contentService;

        public ContentOwnerViewComponent(IContentService contentService)
        {
            _contentService = contentService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int ContentId)
        {
            int UserId = HttpContext.User.GetCurrentUserId();
            var Content = await _contentService.GetContentById(ContentId);
            bool IsOwner=Content.UserId==UserId;
            TempData["ContentId"]=Content.id;
            return View("ContentOwner",IsOwner);
        }
    }
}
