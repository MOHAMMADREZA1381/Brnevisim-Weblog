using Domain.Models;

namespace Domain.IRepositories;

public interface IContactUsRepository
{

    public void CreateNewContactUs(ContactUs contactUs);
    public ICollection<ContactUs> GetAllContactUs();
    public void SaveChanges();


}