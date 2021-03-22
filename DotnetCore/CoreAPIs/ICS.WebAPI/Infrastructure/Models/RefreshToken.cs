using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICS.WebAPI.Infrastructure.Models
{
    public class RefreshToken
    {
        public string UserId { get; set; }
        public string TokenString { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
