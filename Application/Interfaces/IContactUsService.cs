using Domain.Models;
using Domain.ViewModels.ContactUs;

namespace Application.Interfaces;

public interface IContactUsService
{
    public Task AddContactUs(ContactUsViewModel contactUs);
    public Task<ContactUsViewModel> GetContactUsById(int id);
    public Task DeleteContactUs(int id);
    public Task<ICollection<ContactUsViewModel>> GetAllContatcs();
}