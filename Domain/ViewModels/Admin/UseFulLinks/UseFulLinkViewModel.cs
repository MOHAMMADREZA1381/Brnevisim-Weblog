using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels.Admin.UseFulLinks;

public class UseFulLinkViewModel
{
    public int id { get; set; }
    [Required(ErrorMessage = "لطفا نام لینک را وارد کنید")]
    public string LinkName { get; set; }

    [Required(ErrorMessage = "لطفا آدرس لینک را وارد کنید")]
    public string Address { get; set; }

    public bool Footer { get; set; }
}