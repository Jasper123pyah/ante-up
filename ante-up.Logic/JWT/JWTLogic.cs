using System;
using System.Linq;
using System.Security.Claims;
using ante_up.Common.ApiModels;

namespace ante_up.Logic.JWT
{
    public static class JWTLogic
    { 
        public static JWTContainerModel GetJWTContainerModel(string name, string id)
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
        public static JWTContainerModel GetAdminJWTContainerModel(string name, string id)
        {
            return new JWTContainerModel()
            {
                Claims = new Claim[]
                {
                    new Claim(ClaimTypes.Authentication, "thispersonisanadmin"),
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.NameIdentifier, id)
                }
            };
        }
        public static string GetId(string token)
        {
            IAuthService authservice = new JWTService(new JWTContainerModel().SecretKey);
            return authservice.GetTokenClaims(token).ToList().FirstOrDefault(e => e.Type.Equals(ClaimTypes.NameIdentifier))?.Value;
        }
        public static string GetName(string token)
        {
            IAuthService authservice = new JWTService("dafa1f10ce5343fa8ed9316af029162b");
            return authservice.GetTokenClaims(token).ToList().FirstOrDefault(e => e.Type.Equals(ClaimTypes.Name))?.Value;
        }

        public static bool CheckAdminToken(string token)
        {
            IAuthService authService = new JWTService("dafa1f10ce5343fa8ed9316af029162b");
            string adminString = authService.GetTokenClaims(token).ToList().FirstOrDefault(e => 
                    e.Type.Equals(ClaimTypes.Authentication))?.Value;
            
            return adminString == "thispersonisanadmin";
        }
        
        public static string GetToken(JWTContainerModel containerModel)
        {
            IAuthContainerModel model = containerModel;
            IAuthService authService = new JWTService(model.SecretKey);

            string token = authService.GenerateToken(model);

            if (!authService.IsTokenValid(token))
                throw new UnauthorizedAccessException();

            return token;
        }
    }
}