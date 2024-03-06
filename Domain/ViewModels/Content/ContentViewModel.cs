using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.ViewModels.Message;
using Microsoft.AspNetCore.Http;

namespace Domain.ViewModels.Content
{
    public class ContentViewModel:ContentCategoriesViewModel
    {
        public int  id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} محتوا خودرا وارد کنید")]
        [MinLength(15, ErrorMessage = "تعداد حروف {0} نباید کم تر از  15 تا باشد")]
        [MaxLength(120, ErrorMessage = "تعداد حروف {0} نباید بیشتر از 120 تا باشد")] 
        public string Title { get; set; }

        [Display(Name = "مقدمه")]
        [Required(ErrorMessage = "{0} محتوای خود بنویسید")]
        [MinLength(60, ErrorMessage = "تعداد حروف {0} نباید کم تر از  60 تا باشد")]
        [MaxLength(180, ErrorMessage = "تعداد حروف {0} نباید بیشتر از 180 تا باشد")] public string SubTitle { get; set; }
        public DateTime CreateDate { get; set; }

        [Display(Name = "متن اصلی")]
        [Required(ErrorMessage = "{0} محتوای خودرا وارد کنید!")]
        [MinLength(500, ErrorMessage = "{0} محتوا حداقل باید 500حرف باشد!")]
        public string ContentText { get; set; }

        public string? BannerName { get; set; }
        [Display(Name = "بنر")]
        [Required(ErrorMessage ="{0} نباید خالی باشد" )]
        public IFormFile Banner { get; set; }

        [Display(Name = "تگ")]
        [Required(ErrorMessage = "{0} هارا وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} های وارد شده طولانی هستند")]
        public string Tag { get; set; }
        public bool IsDeleted { get; set; }
        public int ViewCount { get; set; } = 0;
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string? UserName { get; set; }
        public string? ProfilePicture { get; set; }
        public bool ShowInGallery { get; set; }
        public ICollection<CaseMessageViewModel>? CaseList { get; set; }
       
    }
}
