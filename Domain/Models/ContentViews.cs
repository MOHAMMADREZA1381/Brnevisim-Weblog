using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ContentViews
    {
        public int id { get; set; }
        public string? UserIp { get; set; }
        public int ContentId { get; set; }
        public DateTime ViewDate { get; set; }=DateTime.Now;

        #region Relations
        [ForeignKey("ContentId")]
        public Content Content { get; set; }
        #endregion
    }
}
