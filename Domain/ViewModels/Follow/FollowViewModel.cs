using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Follow
{
    public class FollowViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserIdThatFollowed { get; set; }
        [Required]
        public string UserNameThatFollowed { get; set; }
        [Required]
        public int UserId { get; set; }

        public string UserProfile { get; set; }
    }
}
