using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Commons
{
    public static class JwtHandler
    {
        private static string GetKey(string key)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build().GetSection("Jwt").GetSection(key).Value;
        }

        private static SecurityTokenDescriptor GetTokenDescriptor(int time, string key, ClaimsIdentity claims)
        {
            return new SecurityTokenDescriptor()
            {
                Issuer = String.Empty,
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(time),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature),
            };
        }

        public static string GenerateAccessToken(TokenClaims? inputClaims)
        {
            ClaimsIdentity claims = new ClaimsIdentity();
            System.Reflection.PropertyInfo[] claimsProps = inputClaims.GetType().GetProperties();
            foreach (var prop in claimsProps) claims.AddClaim(new Claim(prop.Name, prop.GetValue(inputClaims, null)?.ToString() ?? string.Empty));
            SecurityTokenDescriptor tokenDescriptor = GetTokenDescriptor(15, GetKey("Secret"), claims);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken createdToken = handler.CreateJwtSecurityToken(tokenDescriptor);
            return handler.WriteToken(createdToken);
        }
    }
}


