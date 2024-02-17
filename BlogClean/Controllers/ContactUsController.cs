using Domain.ViewModels.ContactUs;
using Microsoft.AspNetCore.Mvc;

namespace BlogClean.Controllers
{
    public class ContactUsController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Contact-Us")]
        public async Task<IActionResult> ContactUsRequest()
        {
            return View();
        }

        [HttpPost("Contact-Us")]
        public async Task<IActionResult> ContactUsRequest(ContactUsViewModel model)
        {
            return View();
        }

    }
}
