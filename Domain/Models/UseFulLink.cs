using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class UseFulLink
{
    public int id { get; set; }
    [Required(ErrorMessage = "لطفا نام لینک را وارد کنید")]
    public string LinkName  { get; set; }
    [Required(ErrorMessage = "لطفا آدرس لینک را وارد کنید")]

    public string Address { get; set; }
    public bool Footer { get; set; }
}