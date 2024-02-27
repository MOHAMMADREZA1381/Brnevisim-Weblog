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
        public async Task<IActionResult> Index(FilterBookmarkViewModel model,string? state)
        {
            int UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            model.UserId = UserId;
            model = await _bookmark.GettBookmarkList(model);
            TempData["MessageType"] = state;
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
            return RedirectToAction("Index", new { state = "Success" });
        }

        [Authorize]
        [Route("Remove-Bookmark")]
        public async Task<IActionResult> RemoveBookmark(int ContentId)
        {
            if (ContentId == 0 || ContentId == null) return PartialView("_NotFoundError");
            bool ContentExist=await _contentService.IsAnyContent(ContentId);
            if (ContentExist==false) return PartialView("_NotFoundError");

            int UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var Bookmark = await _bookmark.getBookmark(ContentId, UserId);
            await _bookmark.RemoveFromBookmark(Bookmark);
            var Filter = new FilterBookmarkViewModel();
            return RedirectToAction("Index", new {state = "Success"});
        }
    }
}
