using UsersChart.Data.Models;
using UsersChart.Data.Seeding.Common;

namespace UsersChart.Data.Seeding;

public class ProjectSeeder : ISeeder
{
    public async Task SeedAsync(UsersChartDbContext dbContext, IServiceProvider serviceProvider)
    {
        var projects = new List<Project>
        {
            new() { Name = "My own" },
            new() { Name = "Free Time" },
            new() { Name = "Work" }
        };

        await dbContext.AddRangeAsync(projects);
    }
}