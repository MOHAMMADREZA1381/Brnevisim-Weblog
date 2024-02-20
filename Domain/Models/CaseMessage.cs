using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CaseMessage
    {
        [Key]
        public int Id { get; set; }
        public int ContentId { get; set; }
        public int UserId { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }

        #region Relation
        public virtual ICollection<Message> Messages { get; set; }
        [ForeignKey("ContentId")]
        public Content Content { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        #endregion
    }
}
