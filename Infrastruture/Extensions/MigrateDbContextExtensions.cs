﻿using Infrastruture.Context;
using Infrastruture.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastruture.Extensions
{
    public static class MigrateDbContextExtensions
    {
        public static void MigrateDbContextServices<TContext>(IServiceScope scope) where TContext : DbContext
        {
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<TContext>>();
            var context = services.GetService<TContext>();

            try
            {
                if (!context!.Database.GetMigrations().Any()) return;
                if (!context!.Database.GetPendingMigrations().Any()) return;
                context.Database.EnsureDeleted();
                logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(TContext).Name);
                context.Database.Migrate();
                logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(TContext).Name);
                
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(TContext).Name);
            }
        }
    }
}
