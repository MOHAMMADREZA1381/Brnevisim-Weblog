using Application.Interfaces;
using Domain.IRepositories;
using Domain.Models;
using Domain.ViewModels.ContactUs;

namespace Application.Services;

public class ContactUsService : IContactUsService
{
    #region Repository
    private readonly IContactUsRepository _contactUs;
    public ContactUsService(IContactUsRepository contactUs)
    {
        _contactUs = contactUs;
    }
    #endregion

    public async Task AddContactUs(ContactUsViewModel contactUs)
    {
        var Contact = new ContactUs();
        Contact.Email = contactUs.Email;
        Contact.Title = contactUs.Title;
        Contact.FullName = contactUs.FullName;
        Contact.Text = contactUs.Text;
        await _contactUs.AddContactUs(Contact);

    }

    public async Task<ContactUsViewModel> GetContactUsById(int id)
    {
        var Contact=await _contactUs.GetContactUsById(id);
        var ContactViewModel = new ContactUsViewModel();
        ContactViewModel.Email=Contact.Email;
        ContactViewModel.Title=Contact.Title;
        ContactViewModel.FullName=Contact.FullName;
        ContactViewModel.Text=Contact.Text;
        ContactViewModel.id = Contact.Id;
        return ContactViewModel;
    }

    public async Task DeleteContactUs(int id)
    {
       await _contactUs.DeleteContactUs(id);
    }
}