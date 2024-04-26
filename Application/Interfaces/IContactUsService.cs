using Domain.Models;
using Domain.ViewModels.ContactUs;

namespace Application.Interfaces;

public interface IContactUsService
{
     Task AddContactUs(ContactUsViewModel contactUs);
     Task<ContactUsViewModel> GetContactUsById(int id);
     Task DeleteContactUs(int id);
     Task<ICollection<ContactUsViewModel>> GetAllContatcs();
}