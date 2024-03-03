using Application.Interfaces;
using Domain.ViewModels.Content;
using Domain.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.ViewCopmponents
{
    public class ContentsUserPanelViewComponent : ViewComponent
    {
        #region Services



        private readonly IContentService _contentService;

        public ContentsUserPanelViewComponent(IContentService contentService)
        {
            _contentService = contentService;
        }
        #endregion

        public async Task<IViewComponentResult> InvokeAsync(int userid)
        {
            var Content = await _contentService.GetUserContentsById(userid);
           
            return View("ContentsUserPanel",Content);
        }
    }
}
