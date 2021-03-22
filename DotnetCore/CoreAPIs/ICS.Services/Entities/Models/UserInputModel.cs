using ICS.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;


namespace ICS.Services.Entities.Models
{
    public class UserInputModel
    {
        public int Id { get; set; }
        public int User_Type_Id { get; set; }
        public int User_Role_Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public DateTime Password_Updated_On { get; set; }
        public byte IsDeleted { get; set; }
        public byte IsLocked { get; set; }
        public int Created_By { get; set; }
        public DateTime Created_On { get; set; }
        public int Updated_By { get; set; }
        public DateTime Updated_On { get; set; }
        public string Email { get; set; }
    }
}
