using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShangYi.Models
{
    public class CategoryModel
    {
		public int ID { get; set; }

		[Display (Name = "CID")]
		public int CID { get; set; }

		[Display (Name = "Pid")]
		public int ParentID { get; set; }

		[Display (Name = "Name")]
		public string Name { get; set; }

		public int Thumbnail { get; set; }

		public bool isLeaf { get; set; }
    }
}
