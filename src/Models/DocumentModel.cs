using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShangYi.Models
{
    public class DocumentModel
    {

        public int id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Index { get; set; }

        [Required]
        public string Content { get; set; }
		
        public byte[] Attachment { get; set; }

        [Required]
        public string Uploader { get; set; }

        [Required]
        public string UID { get; set; }

        public DateTime TimeStamp { get; set; }
        //        ## Document

        //- Title
        //- Index
        //- Content
        //- Attachment
        //- Uploader
        //- Timestamp
        //- UID

    }
}
