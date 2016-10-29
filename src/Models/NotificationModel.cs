using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShangYi.Models
{
    public class NotificationModel
    {
        public int id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Uploader { get; set; }

        [Required]
        public string content { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public string UID { get; set; }

        public DateTime TimeStamp { get; set; }

    }
}
