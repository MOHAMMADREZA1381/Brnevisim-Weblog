using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class ReportContent
{
    [Key]
    public int id { get; set; }
    public int ContentId { get; set; }
    [Display(Name = "دلیل گزارش")]
    [Required(ErrorMessage = "لطفا {0} خودرا وارد کنید")]
    [MinLength(5,ErrorMessage = "{0} نباید کم تر از ۵ حرف باشد")]
    [MaxLength(450, ErrorMessage = "{0} نباید بیشتز از ۴۵۰ حرف باشد")]
    public string ReportText { get; set; }

    #region Relations
    [ForeignKey("ContentId")]
    public  Content Content { get; set; }
    

    #endregion
}