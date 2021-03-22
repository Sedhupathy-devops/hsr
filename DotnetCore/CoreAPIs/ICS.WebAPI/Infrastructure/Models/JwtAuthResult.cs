using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICS.WebAPI.Infrastructure.Models
{
    public class JwtAuthResult
    {
        public string AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
