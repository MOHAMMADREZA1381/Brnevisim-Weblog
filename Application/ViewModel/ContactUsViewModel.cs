using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class ContactUsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Email { get; set; } 
        public string FullName { get; set; }

    }

    public enum State
    {
        Success,
        Failed,
    }
}
