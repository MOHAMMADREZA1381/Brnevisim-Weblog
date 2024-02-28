using Domain.ViewModels.Message;
using Domain.ViewModels.Report;

namespace Domain.ViewModels.Content;

public class ContentDetailsViewModel
{
    public ContentViewModel Content { get; set; }
    public MessageViewModel MessageViewModel { get; set; }
    public AddReportViewModel AddReportViewModel { get; set; }
}