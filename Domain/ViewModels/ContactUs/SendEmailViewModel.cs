namespace Domain.ViewModels.ContactUs;

public class SendEmailViewModel
{
    public ICollection<ContactUsViewModel> ContactUsViewModels { get; set; }
    public EmailViewModel EmailViewModel{ get; set; }
}