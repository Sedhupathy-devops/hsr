using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS.Services.Entities.Models
{
    public class IRDetailsMapping
    {
        public int Id { get; set; }
        public int Request_Id { get; set; }
        public string InterfaceEngine { get; set; }
        public string EnvironmentType { get; set; }
        public string EnvironmentAccessGateway { get; set; }
        public int Created_By { get; set; }
        public DateTime Created_On { get; set; }
        public int Updated_By { get; set; }
        public DateTime Updated_On { get; set; }
        public string MessageStandard { get; set; }
        public string Application { get; set; }
        public string DestinationDetails { get; set; }
    }
}
