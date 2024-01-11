using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModel;
using Domain.IRepositories;
using Domain.Models;

namespace Application.Services
{
    public class ContactUsService:IContactUsService
    {
        private readonly IContactUsRepository _ContactUsRepository;

        public ContactUsService(IContactUsRepository contactUsRepository)
        {
            _ContactUsRepository = contactUsRepository;
        }

        public void CreateNewContactUs(ContactUsViewModel contactUsViewModel)
        {
            var Contact = new ContactUs();
            Contact.Email=contactUsViewModel.Email;
            Contact.FullName = contactUsViewModel.FullName;
            Contact.Text = contactUsViewModel.Text;
            Contact.Title = contactUsViewModel.Title;

            _ContactUsRepository.CreateNewContactUs(Contact);
        }

        public ICollection<ContactUsViewModel> GetAllContactUs()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _ContactUsRepository.SaveChanges();
        }
    }
}
