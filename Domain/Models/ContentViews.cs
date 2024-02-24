﻿using System;
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
        public int UserIp { get; set; }
        public int UserId { get; set; }
        public int ContentId { get; set; }

        #region Relations
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("ContentId")]
        public Content Content { get; set; }
        #endregion
    }
}
