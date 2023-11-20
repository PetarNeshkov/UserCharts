namespace UsersChart.Data.Seeding.Common;

public interface ISeeder
{
    Task SeedAsync(UsersChartDbContext dbContext);
    
}