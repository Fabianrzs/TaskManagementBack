using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Infrastruture.Extensions
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddCorsServices(this IServiceCollection svc, IConfiguration confg)
        {
            var corsPolicy = "CorsPolicy";

            svc.AddCors(options =>
            {
                options.AddPolicy(name: corsPolicy,
                    builder => builder.WithOrigins(confg["AllowedOrigins"].Split(","))
                        //builder => builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        //.SetIsOriginAllowed((host) => true)
                        );
            });

            return svc;
        }
    }
}
