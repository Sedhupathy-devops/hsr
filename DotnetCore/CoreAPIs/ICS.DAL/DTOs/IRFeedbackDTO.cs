using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS.DAL.DTOs
{
    public class IRFeedbackDTO
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int ResourceId { get; set; }
        public DateTime FeedbackRecordedOn { get; set; }
        public string Message { get; set; }
        public int Created_By { get; set; }
        public DateTime Created_On { get; set; }
        public int Updated_By { get; set; }
        public DateTime Updated_On { get; set; }
    }
}
