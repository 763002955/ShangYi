using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShangYi.Models
{
    public class BlobModel
    {
		public int ID { get; set; }

		public string FileName { get; set; }

		public byte[] Content { get; set; }
    }
}
