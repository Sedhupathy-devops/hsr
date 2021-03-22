using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS.DAL.DTOs
{
    public class EnterpriseProfileDTO
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public Byte[] Image { get; set; }
        public byte Is_Active { get; set; }
        public int No_Facilities { get; set; }
        public string Website_Url { get; set; }
        public string Billing_Address { get; set; }
        public string Enterprise_Name { get; set; }
        public string Contact_Person_First_Name { get; set; }
        public string Contact_Person_Last_Name { get; set; }
        public int Contact_Person_Phone_No { get; set; }
        public string Contact_Person_Email { get; set; }
        public string Intergration_Engine_Used { get; set; }
        public string Emr_Or_Registration_System_Used { get; set; }
        public int Created_By { get; set; }
        public DateTime Created_On { get; set; }
        public int Updated_By { get; set; }
        public DateTime Updated_On { get; set; }
    }
}
