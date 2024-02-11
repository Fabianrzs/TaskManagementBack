using Infrastruture.Context;
using Infrastruture.Extensions;
using Infrastruture.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Site.Middleware;
using System.Reflection;

namespace Site
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services; 
            var configuration = builder.Configuration;

            services.AddAppDbContextServices(configuration)
                .AddSwaggerServices().AddAutoMapper(Assembly.Load("Aplication"))
                .AddAuthenticationServices(configuration).AddCorsServices(configuration)
                .AddAplicationRepositories().AddAplicationServices();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            var app = builder.Build();
            var corsPolicy = "CorsPolicy";

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseCors(corsPolicy);
            app.UseAuthorization();
            app.UseAuthentication();
            app.MapControllers();

            InitializeDatabase(app);
            app.Run();
        }
        private static void InitializeDatabase(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
            if (scope == null) return;
            MigrateDbContextExtensions.MigrateDbContextServices<AppDbContext>(scope);
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            if (!context.Database.CanConnect()) return;
            var start = new Start(context!);
            start.Seed().Wait();
        }
    }


}
