using System.Reflection;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using UserChart.Data.Common;
using UsersChart.Data;
using UsersChart.Data.Models;
using UsersChart.Data.Seeding;
using UsersChart.Data.Seeding.Common;

namespace UserChart.Business.InitializeDatabase;

public class InitializeDatabaseService : IInitializeDatabaseService
{
    private readonly UsersChartDbContext dbContext;


    public InitializeDatabaseService(UsersChartDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task InitializeDatabase()
    {
        using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        var dbSetProperties = dbContext.GetType().GetProperties()
            .Where(p => p.PropertyType.IsGenericType 
                        && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

        foreach (var prop in dbSetProperties)
        {    
            dbContext.Database.ExecuteSqlRaw("EXEC sp_MSforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'");

            var entityType = prop.PropertyType.GetGenericArguments().First();
            var tableName = dbContext.Model.FindEntityType(entityType)!.GetTableName();
            var sqlCommand = $"DELETE FROM {tableName}";

            dbContext.Database.ExecuteSqlRaw(sqlCommand);
        }
        await dbContext.SaveChangesAsync();
        
        await SeedDatabase();
        
        scope.Complete();
        
    }

    private async Task SeedDatabase()
    {
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