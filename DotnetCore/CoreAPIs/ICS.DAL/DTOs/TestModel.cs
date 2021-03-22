using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS.Services.Entities.Models
{
    public class TestModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ProjectName { get; set; }
        public int NoInterfaces { get; set; }
        public string ProjectDescription { get; set; }
        public string BudgetUpperLimit { get; set; }
        public string BudgetLowerLimit { get; set; }
        public DateTime ExpectedTimeline { get; set; }
        public byte IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
