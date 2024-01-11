using Application.ViewModel;

namespace Application.Interfaces;

public interface IContactUsService
{
    public void CreateNewContactUs(ContactUsViewModel contactUsViewModel);
    public ICollection<ContactUsViewModel> GetAllContactUs();
    public void SaveChanges();
}