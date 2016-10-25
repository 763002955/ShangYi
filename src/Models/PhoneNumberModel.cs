using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShangYi.Models
{
    public class PhoneNumberModel
    {
		public int ID { get; set; }

		[Required]
		[DisplayName ("部门/职位")]
		public string Department { get; set; }

		[DisplayName ("姓名")]
		public string Name { get; set; }

		[Required]
		[DisplayName ("电话号码")]
		public int Number { get; set; }
    }
}
