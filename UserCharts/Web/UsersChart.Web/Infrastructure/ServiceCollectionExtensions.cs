using Microsoft.EntityFrameworkCore;
using UsersChart.Data;

namespace UsersChart.Web.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDbContext<UsersChartDbContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
}