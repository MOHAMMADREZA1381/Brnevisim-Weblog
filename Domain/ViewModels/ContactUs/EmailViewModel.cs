using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.ContactUs;

public class EmailViewModel
{
    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
    public string Email{ get; set; }
    [Display(Name = "موضوع")]
    [Required(ErrorMessage = "لطفا {0} خود را وارد")]
    [MinLength(15, ErrorMessage = "تعداد کارکتر {0} نباید کمتر از ۱۵ باشد")]
    [MaxLength(120, ErrorMessage = "تعداد کارکتر {0} نباید بیشتر از ۱۲۰ باشد")]
    public string Title { get; set; }
    [Display(Name = "پیام")]
    [Required(ErrorMessage = "لطفا {0} خود را وارد")]
    [MinLength(60, ErrorMessage = "تعداد کارکتر {0} نباید کمتر از ۶۰ باشد")]
    [MaxLength(600, ErrorMessage = "تعداد کارکتر {0} نباید بیشتر از ۶۰۰ باشد")]
    public string Text { get; set; }
}