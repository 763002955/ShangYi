using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShangYi.Models
{
    public class HiringModel
    {
        public int id { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string UID { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
