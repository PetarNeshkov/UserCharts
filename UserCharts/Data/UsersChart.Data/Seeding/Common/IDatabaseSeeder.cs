namespace UsersChart.Data.Seeding.Common;

public interface IDatabaseSeeder
{
    Task SeedDatabase(UsersChartDbContext dbContext, IServiceProvider serviceProvider);

}