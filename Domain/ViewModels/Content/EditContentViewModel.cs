using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.Content;

public class EditContentViewModel:ContentCategoriesViewModel
{
    public int id { get; set; }
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
    public IFormFile? Banner { get; set; }

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