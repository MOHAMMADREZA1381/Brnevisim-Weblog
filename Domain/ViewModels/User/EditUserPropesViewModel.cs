using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.User
{
    public class EditUserPropesViewModel
    {
        public bool IsAdmin { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
