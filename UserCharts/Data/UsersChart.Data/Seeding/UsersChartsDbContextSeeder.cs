using UsersChart.Data.Seeding.Common;

namespace UsersChart.Data.Seeding;

public class UsersChartsDbContextSeeder : ISeeder
{
    public async Task SeedAsync(UsersChartDbContext dbContext, IServiceProvider serviceProvider)
    {
        if (dbContext==null)
        {
            throw new ArgumentNullException(nameof(dbContext));
        }

        if (serviceProvider==null)
        {
            throw new ArgumentNullException(nameof(serviceProvider));
        }

        ClearOldDatabaseEntities(dbContext);
        
        var seeders = new List<ISeeder>
        {
            new UserSeeder(),
            new ProjectSeeder(),
            new TimeLogSeeder()
        };
        
        foreach (var seeder in seeders)
        {
            await seeder.SeedAsync(dbContext, serviceProvider);
            await dbContext.SaveChangesAsync();
        }
    }

    private static void ClearOldDatabaseEntities(UsersChartDbContext usersChartDbContext)
    {
        usersChartDbContext.Users.RemoveRange(usersChartDbContext.Users);
        usersChartDbContext.Projects.RemoveRange(usersChartDbContext.Projects);
        usersChartDbContext.TimeLogs.RemoveRange(usersChartDbContext.TimeLogs);
    }
}