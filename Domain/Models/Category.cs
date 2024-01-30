using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Category
    {
        public int id { get; set; }
        [Display(Name = "نام دسته بندی  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(ErrorMessage = "تعداد کارکتر بیش از حد مجاز")]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
