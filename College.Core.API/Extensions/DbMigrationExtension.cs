using College.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace College.Core.API.Extensions
{
    public static class DbMigrationExtension
    {
        public static void UseDbMigration(this IApplicationBuilder app, bool isDevelopment)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
                //if (isDevelopment)
                //{
                //    DataSeeding.DevelopmentSeeding(context);
                //}
                //else
                //{
                //    DataSeeding.ProductionSeeding(context);
                //}
            }
        }
    }
}
