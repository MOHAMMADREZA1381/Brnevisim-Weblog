using Application.Interfaces;
using Application.SenderEmail;
using Domain.IRepositories;
using Domain.Models;
using Domain.ViewModels.ContactUs;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Areas.AdminPanel.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IContactUsService _contactUsService;
        private readonly IRenderService _Render;

        public ContactController(IContactUsService contactUsService,IRenderService service)
        {
            _contactUsService = contactUsService;
            _Render = service;
        }

        public async Task<IActionResult> Index()
        {
            var ContactUs = new SendEmailViewModel();
            ContactUs.ContactUsViewModels = await _contactUsService.GetAllContatcs();
            
            return View(ContactUs);
        }

        public async Task<IActionResult> Delet(int id)
        {
            await _contactUsService.DeleteContactUs(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EmailSenderTask(EmailViewModel model)
        {
            object Email = model;
            string Body = _Render.RenderToStringAsync("_SendEmail", model);
            EmailSender.Send(model.Email, @model.Title, Body);
            return RedirectToAction("Index");
        }




    }
}
