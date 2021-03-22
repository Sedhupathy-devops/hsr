using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS.DAL.DTOs
{
    public class IRDocumentsMappingDTO
    {
        public int RequestId { get; set; }
        public int DocumentType { get; set; }
        public int DocumentUrl { get; set; }
        public int IsDeleted { get; set; }
        public int Created_By { get; set; }
        public DateTime Created_On { get; set; }
        public int Updated_By { get; set; }
        public DateTime Updated_On { get; set; }
        public byte[] File { get; set; }
    }
}
