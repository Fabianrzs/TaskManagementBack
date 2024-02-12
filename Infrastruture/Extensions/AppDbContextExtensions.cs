using Infrastruture.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastruture.Extensions
{
    public static class AppDbContextExtensions
    {
        public static IServiceCollection AddAppDbContextServices(this IServiceCollection svc, IConfiguration confg)
        {
            svc.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(confg.GetConnectionString("DefaultConnection")
                .Replace("{{DB_ENDPOINT}}", confg.GetValue<string>("DB_ENDPOINT"))));

            svc.AddTransient<MongoDbContext>();

            return svc;
        }
    }
}
