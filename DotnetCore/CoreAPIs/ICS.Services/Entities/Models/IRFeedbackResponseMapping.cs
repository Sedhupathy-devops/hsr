using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS.Services.Entities.Models
{
    public class IRFeedbackResponseMapping
    {
        public int Id { get; set; }
        public int FeedbackId { get; set; }
        public string Response { get; set; }
        public DateTime ResponseRecordedOn { get; set; }
        public byte IsDeleted { get; set; }
        public int Created_By { get; set; }
        public DateTime Created_On { get; set; }
        public int Updated_By { get; set; }
        public DateTime Updated_On { get; set; }
    }
}
