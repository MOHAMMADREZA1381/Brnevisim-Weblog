using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.User;

public class ActiveMobileCodeViewModel
{
    [Required(ErrorMessage = "لطفا کد فعالسازی را وارد کنید")]
    [MaxLength(5,ErrorMessage = "کد فعالسازی تا 5 رقم است")]
    public string ActiveCode { get; set; }
}