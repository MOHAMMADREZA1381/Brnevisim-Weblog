using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.User
{
    public class AdminUsersViewModel
    {
        [Required]
        public RegisterViewModel Register { get; set; }
        public ICollection<UserViewModel> Users { get; set; }
    }
}
