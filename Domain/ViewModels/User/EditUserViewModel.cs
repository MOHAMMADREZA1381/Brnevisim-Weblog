using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.User;

public class EditUserViewModel
{
    [Display(Name = "نام کاربری  ")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string UserName { get; set; }
    [Display(Name = "عکس کاربر")]
    public string? UserImage { get; set; }
    [Display(Name = "عکس کاربر")]
    public IFormFile? Image { get; set; }
    [Display(Name = "شماره تلفن همراه")]
    [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string? phoneNumber { get; set; }
    [Display(Name = "بایو")]
    [MinLength(15, ErrorMessage = "{0} نباید کمتر از 15 حرف باشد")]
    [MaxLength(250, ErrorMessage = "{0} نباید بیشتر از ۲۵۰ حرف باشد")]
    public string? Bio { get; set; }

    public string? Email { get; set; }
    public bool MobileActivated { get; set; }
}