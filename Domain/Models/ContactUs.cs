using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ContactUs
    {
        public int Id { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد")]
        [MinLength(5, ErrorMessage = "تعداد کارکتر {0} نباید کمتر از ۵ باشد")]
        [MaxLength(35, ErrorMessage = "تعداد کارکتر {0} نباید بیشتر از ۳۵ باشد")]
        public string FullName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }

        [Display(Name = "موضوع")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد")]
        [MinLength(15, ErrorMessage = "تعداد کارکتر {0} نباید کمتر از ۱۵ باشد")]
        [MaxLength(120, ErrorMessage = "تعداد کارکتر {0} نباید بیشتر از ۱۲۰ باشد")]
        public string Title { get; set; }

        [Display(Name = "نظرات")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد")]
        [MinLength(60, ErrorMessage = "تعداد کارکتر {0} نباید کمتر از ۶۰ باشد")]
        [MaxLength(600, ErrorMessage = "تعداد کارکتر {0} نباید بیشتر از ۶۰۰ باشد")]
        public string Text { get; set; }


    }
}
