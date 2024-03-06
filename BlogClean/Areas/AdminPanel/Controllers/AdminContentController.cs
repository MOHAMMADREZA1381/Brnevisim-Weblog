using Application.Interfaces;
using Domain.ViewModels.Content;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Areas.AdminPanel.Controllers
{
    public class AdminContentController : BaseController
    {
        #region Services

        

        private readonly IContentService _contentService;

        public AdminContentController(IContentService contentService)
        {
            _contentService = contentService;
        }
        #endregion

        public async Task<IActionResult> Index(FilterContentViewModel model)
        {
            var Contents = await _contentService.GetContentWithFilter(model);
            return View(Contents);
        }

        public async Task<IActionResult> AddToGallery(List<int> ContentsId)
        {
            if (ContentsId.Count!=0)
            {
                await _contentService.AddContentToGallery(ContentsId);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveFromGallery(List<int> ContentsId)
        {
            if (ContentsId.Count != 0)
            {
                await _contentService.RemoveContentFromGallery(ContentsId);
            }
            return RedirectToAction("Index");
        }
    }
}
