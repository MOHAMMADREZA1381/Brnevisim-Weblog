using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Following
    {
        public int Id { get; set; }
        [Required]
        public int UserIdThatFollowed { get; set; }
        [Required]
        public string UserNameThatFollowed { get; set; }
        public int  UserId { get; set; }

        #region Relations
        [ForeignKey("UserId")]
        public User User { get; set; }

        #endregion
    }
}
