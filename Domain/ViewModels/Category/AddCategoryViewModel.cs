using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.Category;

public class AddCategoryViewModel
{
    [Display(Name = "نام دسته بندی  ")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(ErrorMessage = "تعداد کارکتر بیش از حد مجاز")]
    public string Name { get; set; }   
}