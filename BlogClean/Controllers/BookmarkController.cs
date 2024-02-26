using System.Security.Claims;
using Application.Interfaces;
using Domain.ViewModels.Bookmark;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Controllers
{
    public class BookmarkController : Controller
    {
        #region Service
        private readonly IBookmarkService _bookmark;
        private readonly IContentService _contentService;
        public BookmarkController(IBookmarkService bookmark, IContentService contentService)
        {
            _bookmark = bookmark;
            _contentService = contentService;
        }
        #endregion
        [Authorize]
        [Route("my-boomarks")]
        public async Task<IActionResult> Index(FilterBookmarkViewModel model)
        {
            int UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            model.UserId = UserId;
            model = await _bookmark.GettBookmarkList(model);
            return View(model);
        }
        [Authorize]
        [Route("Add-To-MyBookmark")]
        public async Task<IActionResult> AddBookmark(int ContentId)
        {
            bool ContentExist = await _contentService.IsAnyContent(ContentId);
            if (ContentExist == false) return PartialView("_NotFoundError");
            
            var UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var Bookmark = new BookmarkViewModel()
            {
                UserId = UserId,
                ContentId = ContentId,
            };
            await _bookmark.AddBookmark(Bookmark);
            return RedirectToAction("Index");
        }
    }
}
