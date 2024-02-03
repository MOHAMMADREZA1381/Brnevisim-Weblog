using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Content
{
    public class ContentViewModel:EditContentViewModel
    {

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} محتوا خودرا وارد کنید")]
        [StringLength(75, ErrorMessage = "لطفا ورودی '{0}' را بررسی کنید", MinimumLength = 15)]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "{0} محتوای خود بنویسید")]
        [StringLength(180, ErrorMessage = "لطفا ورودی '{0}' را بررسی کنید", MinimumLength = 70)]
        public string SubTitle { get; set; }
        public DateTime CreateDate { get; set; }

        [Display(Name = "متن اصلی")]
        [Required(ErrorMessage = "{0} محتوای خودرا وارد کنید!")]
        [MinLength(500, ErrorMessage = "{0} محتوا حداقل باید 500حرف باشد!")]
        public string ContentText { get; set; }
        public string? Banner { get; set; }

        [Display(Name = "تگ")]
        [Required(ErrorMessage = "{0} هارا وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} های وارد شده طولانی هستند")]
        public string Tag { get; set; }
        public bool IsDeleted { get; set; }
        public int ViewCount { get; set; } = 0;
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string UserName { get; set; }
    }
}
