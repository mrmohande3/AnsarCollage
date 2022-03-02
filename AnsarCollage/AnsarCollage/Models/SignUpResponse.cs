using System;
using System.Collections.Generic;
using System.Text;

namespace AnsarCollage.Models
{
    public class BToken
    {
        public string Token { get; set; }
    }
    public class TokenData
    {
        public string Status { get; set; }
        public BToken Data { get; set; }
    }
    public class TokenResponse
    {
        public TokenData Token { get; set; }
    }
    public class SignUpResponse
    {
        public string Status { get; set; }
    }
}
