using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.Report;

public class AddReportViewModel
{
    public int ContentId { get; set; }
    [Display(Name = "دلیل گزارش")]
    [Required(ErrorMessage = "لطفا {0} خودرا وارد کنید")]
    [MinLength(5, ErrorMessage = "{0} نباید کم تر از ۵ حرف باشد")]
    [MaxLength(450, ErrorMessage = "{0} نباید بیشتز از ۴۵۰ حرف باشد")]
    public string ReportText { get; set; }
}