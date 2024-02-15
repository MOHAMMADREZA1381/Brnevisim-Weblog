using Application.ImageTools;
using Application.Interfaces;
using Domain.ViewModels.Content;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Application.ImageTools.Common;
using Persia_.NET_Core;
namespace BlogClean.Controllers
{
    [Authorize]
    public class ContentController : Controller
    {
        #region Services
        private readonly IContentService _contentService;
        private readonly ICategoryService _categoryService;

        public ContentController(IContentService contentService,ICategoryService categoryService)
        {
            _contentService = contentService;
            _categoryService = categoryService;
        }
        #endregion

        public async Task<IActionResult> Index(FilterContentViewModel viewModel)
        {
            viewModel.TakeEntity = 2;
            var Content = await _contentService.GetContentWithFilter(viewModel);
           
            return View(Content);
        }

        [HttpGet("Add-Content")]
        public async Task<IActionResult> CreateContent()
        {

            var ContentViewModel = new ContentViewModel();
            ContentViewModel.CategoryViewModels =await _categoryService.GetAllCategories();
            ContentViewModel.UserId =int.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            return View(ContentViewModel);
        }

        [HttpPost("Add-Content")]
        public async Task<IActionResult> CreateContent(ContentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _contentService.CreateContentTask(viewModel);
               return RedirectToAction("Index");
            }
            viewModel.CategoryViewModels=await _categoryService.GetAllCategories();
            viewModel.UserId = int.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(viewModel);
        }


        public JsonResult UploadImagesContentCkEditorTask()
        {
            var MyFiles = Request.Form.Files;
            if (MyFiles.Count==0)
            {
                var FileNotFound = new
                {
                    uploaded=false,
                    url=string.Empty,
                };
                return Json(FileNotFound);
            }
            var File = MyFiles[0];
            var FileName=Guid.NewGuid()+File.FileName;
            File.AddImageToServer(FileName, PathExtensions.ContentImgOrginServer, 300, 300, PathExtensions.ContentImgThumbServer);
            var pathFile= "./images/ContentImages/origin/" + FileName;
            var Success = new
            {
                uploaded = true,
                Url = pathFile,
            };
            return Json(Success);
        }
    }
}
