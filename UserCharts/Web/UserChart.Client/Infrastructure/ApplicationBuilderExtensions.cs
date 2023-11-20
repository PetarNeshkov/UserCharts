using Microsoft.EntityFrameworkCore;
using UsersChart.Data;
using UsersChart.Data.Seeding;

namespace UserChart.Client.Infrastructure;

public static class ApplicationBuilderExtensions
{
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetRequiredService<UsersChartDbContext>();

            data.Database.Migrate();

            SeedData(app);

            return app;
        }

        private static void SeedData(this IApplicationBuilder app)
        {
            using var scopedService= app.ApplicationServices.CreateScope();

            using var dbContext=scopedService.ServiceProvider.GetRequiredService<UsersChartDbContext>();

            new UsersChartsDbContextSeeder()
                .SeedDatabase(dbContext, scopedService.ServiceProvider)
                .GetAwaiter()
                .GetResult();
        }
}