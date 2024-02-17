using Application.Interfaces;
using Domain.ViewModels.ContactUs;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Controllers
{
    public class ContactUsController : Controller
    {
        #region Service

        private readonly IContactUsService _contactUsService;
        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }
        #endregion


        [HttpGet("Contact-Us")]
        public async Task<IActionResult> Index()
        {
     
            return View();
        }

        [HttpPost("Contact-Us")]
        public async Task<IActionResult> Index(ContactUsViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _contactUsService.AddContactUs(model);
                ModelState.Clear();
                TempData["MessageType"] = "Success";
            }
            else
            {
              TempData["MessageType"] = "Error";
            }

            return View();
        }

    }
}
