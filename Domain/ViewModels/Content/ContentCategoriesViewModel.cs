using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ViewModels.Category;

namespace Domain.ViewModels.Content
{
    public class ContentCategoriesViewModel
    {
        public ICollection<CategoryViewModel>? CategoryViewModels { get; set; }
    }
}
