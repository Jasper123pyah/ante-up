using System;
using System.Linq;
using System.Security.Claims;

namespace ante_up.Logic.JWT
{
    public class JWTLogic
    { 
        private static JWTContainerModel GetJWTContainerModel(string name, string id)
        {
            return new JWTContainerModel()
            {
                Claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.NameIdentifier, id)
                }
            };
        }
        public string GetId(string token)
        {
            IAuthService authservice = new JWTService("dafa1f10ce5343fa8ed9316af029162b");
            return authservice.GetTokenClaims(token).ToList().FirstOrDefault(e => e.Type.Equals(ClaimTypes.NameIdentifier))?.Value;
        }
        public string GetName(string token)
        {
            IAuthService authservice = new JWTService("dafa1f10ce5343fa8ed9316af029162b");
            return authservice.GetTokenClaims(token).ToList().FirstOrDefault(e => e.Type.Equals(ClaimTypes.Name))?.Value;
        }
        public string GetToken(string name, string accountId)
        {
            IAuthContainerModel model = GetJWTContainerModel(name, accountId);
            IAuthService authService = new JWTService(model.SecretKey);

            string token = authService.GenerateToken(model);

            if (!authService.IsTokenValid(token))
                throw new UnauthorizedAccessException();

            return token;
        }
    }
}