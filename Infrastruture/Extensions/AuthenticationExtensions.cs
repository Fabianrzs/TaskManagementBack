using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastruture.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAuthenticationServices(this IServiceCollection svc, IConfiguration confg)
        {

            string SecretKey = confg.GetSection("Jwt").GetSection("SecretKey").Value;
            string RefreshSecretKey = confg.GetSection("Jwt").GetSection("RefreshSecretKey").Value;
            string EncrypterKey = confg.GetSection("Jwt").GetSection("EncrypterKey").Value;
            string Audience = confg.GetSection("Jwt").GetSection("Audience").Value;

            svc.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer("Jwt", jwt =>
                {
                    jwt.RequireHttpsMetadata = false;
                    jwt.SaveToken = true;
                    jwt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey)),
                        TokenDecryptionKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(EncrypterKey)),
                        ValidAudience = Audience,
                        ValidateIssuer = false,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                    };
                })
                .AddJwtBearer("Refresh", jwt =>
                {
                    jwt.RequireHttpsMetadata = false;
                    jwt.SaveToken = true;
                    jwt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(RefreshSecretKey)),
                        TokenDecryptionKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(EncrypterKey)),
                        ValidAudience = Audience,
                        ValidateIssuer = false,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                    };
                });

            svc.AddAuthorization(options =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder("Jwt", "AzureAd");
                defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });
            return svc;
        }
    }
}
