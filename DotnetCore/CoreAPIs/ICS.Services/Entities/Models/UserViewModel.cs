using System;
using System.Collections.Generic;
using System.Text;

namespace ICS.Services.Entities.Models
{
    public class UserViewModel
    {
        public UserInputModel userDetails { get; set; }
        public UserTokenModel userToken { get; set; }
    }
}
