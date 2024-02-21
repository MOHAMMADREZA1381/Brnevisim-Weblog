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
        private readonly IContentService _contentService;

        public MessageController(IMessageService messageService, ICaseMessageService caseMessageService, IUserService userService, IContentService contentService)
        {
            _messageService = messageService;
            _caseMessageService = caseMessageService;
            _userService = userService;
            _contentService = contentService;
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
        [Route("Edit-Message")]
        [Authorize]
        public async Task<IActionResult> EditMessage(MessageViewModel model)
        {
            var UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var MessageCreatedBefor = await _messageService.CreatedBefor(model.id);
            var ContentExist = await _contentService.IsAnyContent(model.ContentId);
            model.CaseId = 0;
            if (MessageCreatedBefor == true && ContentExist == true && ModelState.IsValid)
            {
                var MessageBlongToUser = await _messageService.MessageBlongToUser(UserId, model.id);
                if (MessageBlongToUser == true)
                {
                    await _messageService.EditMessage(model);
                    return RedirectToAction("ContentDetails", "Content", new { id = model.ContentId, state = "Success" });
                }
            }
            if (MessageCreatedBefor == false || ContentExist == false)
            {
                return PartialView("_NotFoundError");
            }
            return RedirectToAction("ContentDetails", "Content", new { id = model.ContentId, state = "Error" });

        }
    }
}
