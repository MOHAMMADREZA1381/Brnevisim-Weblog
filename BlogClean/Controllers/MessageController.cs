using Application.Interfaces;
using Domain.ViewModels.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.Identity.Client;

namespace BlogClean.Controllers
{
    public class MessageController : Controller
    {
        #region Services
        private readonly IMessageService _messageService;
        private readonly ICaseMessageService _caseMessageService;
        private readonly IUserService _userService;
        public MessageController(IMessageService messageService, ICaseMessageService caseMessageService, IUserService userService)
        {
            _messageService = messageService;
            _caseMessageService = caseMessageService;
            _userService = userService;
        }
        #endregion

        [Authorize]
        public async Task<IActionResult> AddMessage(MessageViewModel model)
        {
            int UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            model.UserId = UserId;
            if (ModelState.IsValid)
            {
                await _messageService.AddMessage(model);
                return RedirectToAction("ContentDetails", "Content", new { id = model.ContentId, state = "Success" });

            }
            return RedirectToAction("ContentDetails", "Content", new { id = model.ContentId, state = "Error" });

        }
    }
}
