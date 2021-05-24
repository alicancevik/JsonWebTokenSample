using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonWebTokenSample.API.Models
{
    public class LoginDto
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class MyAccessTokenDto
    {
        public string Type { get; set; }

        public string AccessToken { get; set; }
    }
}
