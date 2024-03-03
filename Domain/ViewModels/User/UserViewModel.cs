using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Domain.ViewModels.User
{
    public class UserViewModel:EditUserPropesViewModel
    {
        public int id { get; set; }
        [Display(Name = "نام کاربری  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }

        [Display(Name = "شماره تلفن همراه")]
        [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public int? Phone { get; set; }

        [Display(Name = "بایو")]
        [MinLength(15, ErrorMessage = "{0} نباید کمتر از 15 حرف باشد")]
        [MaxLength(250, ErrorMessage = "{0} نباید بیشتر از ۲۵۰ حرف باشد")]
        public string? Bio { get; set; }

        [Display(Name = "عکس کاربر")]
        public string? picProfile { get; set; }

        [Display(Name = "عکس کاربر")]
        public IFormFile? UserImg { get; set; }

        public string ActivateCode { get; set; }
        public bool IsAdmin { get; set; }
    }
}
