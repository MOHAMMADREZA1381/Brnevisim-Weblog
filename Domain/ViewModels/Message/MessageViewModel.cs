using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.Message;

public class MessageViewModel:EditMessageViewModel
{
    [Display(Name = "متن")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MinLength(5, ErrorMessage = "{0} نباید کم تر از 5 حرف باشد")]
    [MaxLength(255, ErrorMessage = "{0} نباید بیشتر از 255 حرف باشد")]
    public string text { get; set; }
    public int UserId { get; set; }
    public int ContentId { get; set; }
    public int CaseId { get; set; }
    public string? ProfileNamePic { get; set; }
    public string? Name { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsFirstMessage { get; set; }
}