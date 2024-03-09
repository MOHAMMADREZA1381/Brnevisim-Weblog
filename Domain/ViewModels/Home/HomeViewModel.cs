using Domain.ViewModels.Category;
using Domain.ViewModels.Content;

namespace Domain.ViewModels.Home;

public class HomeViewModel
{
  
    public IEnumerable<ContentViewModel> MostViewContent { get; set; }
    public IEnumerable<ContentViewModel> LastContent { get; set; }
    public IEnumerable<ContentViewModel> AllContent { get; set; }
    public ICollection<ContentViewModel> GalleryCollection { get; set; }
    public FilterContentViewModel FilterContentViewModel { get; set; }
}