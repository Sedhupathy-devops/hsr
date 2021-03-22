using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS.DAL.DTOs
{
    public class InterfaceRequestDTO
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string Project_Name { get; set; }
        public int No_Interfaces { get; set; }
        public string Project_Description { get; set; }
        public string Budget_Upper_Limit { get; set; }
        public string Budget_Lower_Limit { get; set; }
        public DateTime Expected_Timeline { get; set; }
        public byte IsDeleted { get; set; }
        public int Created_By { get; set; }
        public DateTime Created_On { get; set; }
        public int Updated_By { get; set; }
        public DateTime Updated_On { get; set; }
        public int Order_Status_Id { get; set; }
        public DateTime Start_Date { get; set; }
        //public List<IRDetailsMappingDTO> InterfaceDetailsList { get; set; }
    }
}
