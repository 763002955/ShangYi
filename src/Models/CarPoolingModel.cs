using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShangYi.Models
{
    public class CarPoolingModel
    {
        public int id { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public  string From { get; set; }

        [Required]
        public string To { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public string UID { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
