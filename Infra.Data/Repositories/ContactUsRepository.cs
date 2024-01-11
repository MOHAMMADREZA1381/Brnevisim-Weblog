using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.IRepositories;
using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly BlogContext _blogContext; 
        public ContactUsRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }


        public void CreateNewContactUs(ContactUs contactUs)
        {
            _blogContext.ContactUs.Update(contactUs);
        }

        public ICollection<ContactUs> GetAllContactUs()
        {
            return _blogContext.ContactUs.ToList();
        }

        public void SaveChanges()
        {
            _blogContext.SaveChanges();
        }
    }
}
