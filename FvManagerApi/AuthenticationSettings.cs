using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FvManagerApi
{
    public class AuthenticationSettings
    {
        public string JwtKey { get; set; }
        public int JwtExpireTime { get; set; }
        public string JwtIssuer { get; set; }
    }
}
