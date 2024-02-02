using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        //todo get count of category content
        //public int? ContentCount { get; set; }
    }
}
