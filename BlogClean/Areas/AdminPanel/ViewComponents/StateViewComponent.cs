using Application.Interfaces;
using Domain.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Areas.AdminPanel.ViewComponents
{
    public class StateViewComponent : ViewComponent
    {
        private readonly IContentService _contentService;
        private readonly IViewCountService _viewCountService;
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        public StateViewComponent(IContentService contentService, IViewCountService viewCountService, IMessageService messageService,IUserService userService)
        {
            _contentService = contentService;
            _viewCountService = viewCountService;
            _messageService = messageService;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ContentsCount = await _contentService.AllContents();
            var User = await _userService.GetUsers();
            var state = new StateViewModel()
            {
                AllContent =ContentsCount.Count(),
                MessagesCount = await _messageService.messageCount(),
                TodayView = await _viewCountService.ViewCount(),
                UserCount = User.Count
            };

            return View("State",state);
        }
    }
}
