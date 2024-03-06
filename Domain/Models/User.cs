using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public int Id { get; set; }

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
        public string? Phone { get; set; }

        [Display(Name = "کد فعال سازی")]
        public string ActivateCode { get; set; }

        [Display(Name = "فعال / غیرفعال")]
        public bool IsActive { get; set; }

        [Display(Name = "عکس کاربر")]
        public string? UserImg { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Password { get; set; }

        public string MobileActivateCode { get; set; }
        public bool MobileActivated { get; set; }
        public bool IsDelete { get; set; }
        public bool IsAdmin { get; set; }
        [Display(Name = "بایو")]
        [MinLength(15,ErrorMessage = "{0} نباید کمتر از 15 حرف باشد")]
        [MaxLength(250,ErrorMessage = "{0} نباید بیشتر از ۲۵۰ حرف باشد")]
        public string? Bio { get; set; }
        #region Relations
        public ICollection<Content> Contents { get; set; }
        public ICollection<ContentViews>ViewsCollection { get; set; }
        public ICollection<Following> Followings { get; set; }
        public ICollection<Bookmark> Bookmarks { get; set; }

        #endregion
    }
}
