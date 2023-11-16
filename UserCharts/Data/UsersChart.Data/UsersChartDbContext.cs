using Microsoft.EntityFrameworkCore;
using UsersChart.Data.Models;

namespace UsersChart.Data;

public class UsersChartDbContext : DbContext
{
    public UsersChartDbContext(DbContextOptions<UsersChartDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; init; }
    
    public DbSet<Project> Projects { get; init; }
    
    public DbSet<TimeLog> TimeLogs { get; init; }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => SaveChangesAsync(true, cancellationToken);
}