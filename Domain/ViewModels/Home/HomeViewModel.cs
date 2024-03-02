using Domain.ViewModels.Category;
using Domain.ViewModels.Content;

namespace Domain.ViewModels.Home;

public class HomeViewModel
{
    public ICollection<CategoryViewModel> CategoryViewModels { get; set; }
    public ICollection<ContentViewModel> MostViewContent { get; set; }
    public ICollection<ContentViewModel> LastContent { get; set; }
    public ICollection<ContentViewModel> AllContent { get; set; }
    
}