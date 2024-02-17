using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.User;

public class ForgotPasswordViewModel
{
    public string ActivateCode  { get; set; }
    [Display(Name = "رمز عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Password { get; set; }

    [Display(Name = "تکرار عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    [Compare("Password", ErrorMessage = "رمز های عبور متفاوت هستند")]
    public string ConfirmPassword { get; set; }
}