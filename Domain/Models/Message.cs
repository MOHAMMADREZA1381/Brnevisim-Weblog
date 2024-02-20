
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string Text { get; set; }
        public bool IsDelete{ get; set; }
        public int UserId { get; set; }
        public int CaseId { get; set; }
        public int ContentId { get; set; }
        public bool IsFirstMesage { get; set; }
        #region Relations
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("CaseId")]
        public CaseMessage Case { get; set; }
  
        [ForeignKey("ContentId")]
        public Content Content { get; set; }

       

        #endregion
    }
}
