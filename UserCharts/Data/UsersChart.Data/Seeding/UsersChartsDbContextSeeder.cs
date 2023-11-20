using UsersChart.Data.Seeding.Common;

namespace UsersChart.Data.Seeding;

public class UsersChartsDbContextSeeder : IDatabaseSeeder
{
    public async Task SeedDatabase(UsersChartDbContext dbContext, IServiceProvider serviceProvider)
    {
        if (dbContext == null)
        {
            throw new ArgumentNullException(nameof(dbContext));
        }

        if (serviceProvider == null)
        {
            throw new ArgumentNullException(nameof(serviceProvider));
        }
        
        var seeders = new List<ISeeder>
        {
            new UserSeeder(),
            new ProjectSeeder(),
            new TimeLogSeeder()
        };

        foreach (var seeder in seeders)
        {
            await seeder.SeedAsync(dbContext);
            await dbContext.SaveChangesAsync();
        }
    }
    
}