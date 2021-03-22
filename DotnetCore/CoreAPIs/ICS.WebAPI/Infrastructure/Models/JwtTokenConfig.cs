using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ICS.WebAPI.Infrastructure.Models
{
    public class JwtTokenConfig
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
    }
}
