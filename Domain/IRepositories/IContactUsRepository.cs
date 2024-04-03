using Domain.Models;

namespace Domain.IRepositories;

public interface IContactUsRepository
{
    public  Task AddContactUs(ContactUs contactUs);
    public Task<ContactUs> GetContactUsById(int id);
    public Task DeleteContactUs(ContactUs contactUs);
    public Task<ICollection<ContactUs>> GetAll();
    public Task SaveAsync();
}