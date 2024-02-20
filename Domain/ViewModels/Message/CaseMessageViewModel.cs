using System.Security.AccessControl;

namespace Domain.ViewModels.Message;

public class CaseMessageViewModel
{
    public int  id { get; set; }
    public int ContentId { get; set; }
    public int UserId { get; set; }
    public ICollection<MessageViewModel> Messages { get; set; }

}