using System;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace ante_up.Logic.JWT
{
    public class JWTContainerModel : IAuthContainerModel
    {
        public int ExpireMinutes { get; set; } = 40320; //28 days
        public string SecretKey { get; set; } = "dafa1f10ce5343fa8ed9316af029162b" ?? "lmao";
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;
        public Claim[] Claims { get; set; }
    }
}