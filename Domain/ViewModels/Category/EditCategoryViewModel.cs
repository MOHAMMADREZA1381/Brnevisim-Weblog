using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Category
{
    public class EditCategoryViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

    }
}
