using Domain.Models;

namespace Domain.IRepositories;

public interface IContactUsRepository
{
      Task AddContactUs(ContactUs contactUs);
     Task<ContactUs> GetContactUsById(int id);
     Task DeleteContactUs(ContactUs contactUs);
     Task<ICollection<ContactUs>> GetAll();
     Task SaveAsync();
}