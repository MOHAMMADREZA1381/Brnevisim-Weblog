using Application.ImageTools;
using Application.Interfaces;
using Domain.ViewModels.Content;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Application.ImageTools.Common;
using Domain.ViewModels.Message;
using Persia_.NET_Core;
namespace BlogClean.Controllers
{

    public class ContentController : Controller
    {
        #region Services
        private readonly IContentService _contentService;
        private readonly ICategoryService _categoryService;

        public ContentController(IContentService contentService, ICategoryService categoryService)
        {
            _contentService = contentService;
            _categoryService = categoryService;
        }
        #endregion

        #region ContentList
        [Route("ContentList")]
        public async Task<IActionResult> Index(FilterContentViewModel viewModel)
        {

            var Content = await _contentService.GetContentWithFilter(viewModel);

            return View(Content);
        }
        #endregion

        #region ContentDetails
        [Route("Content-Details")]
        public async Task<IActionResult> ContentDetails(int id,int? HowManyCaseShow, string? state)
        {
            TempData["MessageType"] = state;
            ///for load more case message
            if (HowManyCaseShow==null || HowManyCaseShow==0)
            {
                HowManyCaseShow = 4;
            }
            TempData["HowManyShowCase"]=HowManyCaseShow.Value;

            bool ContentExist = await _contentService.IsAnyContent(id);
            var ContentViewModel = new ContentDetailsViewModel();
            if (ContentExist==true)
            {
                var Content = await _contentService.GetContentById(id);
                var Message = new MessageViewModel();
                Message.ContentId = Content.id;
                ContentViewModel.MessageViewModel= Message;

                var caseMessageViewModels = Content.CaseList.Take(HowManyCaseShow.Value);
                Content.CaseList = caseMessageViewModels.ToList();
                ContentViewModel.Content = Content;
                return View(ContentViewModel);
            }

            return PartialView("_NotFoundError");
        }

        #endregion

        #region Create Content

        [Authorize]
        [HttpGet("Add-Content")]
        public async Task<IActionResult> CreateContent()
        {

            var ContentViewModel = new ContentViewModel();
            ContentViewModel.CategoryViewModels = await _categoryService.GetAllCategories();
            ContentViewModel.UserId = int.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            return View(ContentViewModel);
        }
        [Authorize]
        [HttpPost("Add-Content")]
        public async Task<IActionResult> CreateContent(ContentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _contentService.CreateContentTask(viewModel);
                return RedirectToAction("Index");
            }
            viewModel.CategoryViewModels = await _categoryService.GetAllCategories();
            viewModel.UserId = int.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(viewModel);
        }

        [Authorize]
        public JsonResult UploadImagesContentCkEditorTask()
        {
            var MyFiles = Request.Form.Files;
            if (MyFiles.Count == 0)
            {
                var FileNotFound = new
                {
                    uploaded = false,
                    url = string.Empty,
                };
                return Json(FileNotFound);
            }
            var File = MyFiles[0];
            var FileName = Guid.NewGuid() + File.FileName;
            File.AddImageToServer(FileName, PathExtensions.ContentImgOrginServer, 300, 300, PathExtensions.ContentImgThumbServer);
            var pathFile = "./images/ContentImages/origin/" + FileName;
            var Success = new
            {
                uploaded = true,
                Url = pathFile,
            };
            return Json(Success);
        }
        #endregion

        #region EditContent
        [HttpGet("Edit-Content")]
        public async Task<IActionResult> EditContent(int id)
        {
            var Content = await _contentService.GetContentForEdit(id);
            Content.CategoryViewModels = await _categoryService.GetAllCategories();

            return View(Content);
        }
        [HttpPost("Edit-Content")]
        public async Task<IActionResult> EditContent(EditContentViewModel model)
        {

            if (ModelState.IsValid)
            {
                await _contentService.Edit(model);
                return RedirectToAction("Index");

            }
            var Categories = await _categoryService.GetAllCategories();
            model.CategoryViewModels = Categories;
            return View(model);
        }
        #endregion

        #region DeleteContent
        [Authorize]
        public async Task<IActionResult> DeleteContent(int id)
        {
            var UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var Result = await _contentService.DeletContent(id, UserId);
            if (Result == State.Success)
            {
                return RedirectToAction("Index");
            }
            // todo : return redirect to ContentDetails if State=Failed
            return RedirectToAction("Index");
        }

        #endregion

    }
}
