using Microsoft.EntityFrameworkCore;
using UserChart.Business.InitializeDatabase;
using UserChart.Business.TimeLogs;
using UserChart.Data.TimeLogs;
using UsersChart.Data;

namespace UserChart.Client.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDbContext<UsersChartDbContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    
    public static IApplicationBuilder UseAnyCors(
        this IApplicationBuilder app)
        => app
            .UseCors(options => options
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

    public static IApplicationBuilder UseEndpoints(
        this IApplicationBuilder app)
        => app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddSingleton(configuration)
            .AddScoped<ITimeLogDataService, TimeLogDataService>()
            .AddScoped<ITimeLogService, TimeLogService>()
            .AddScoped<IInitializeDatabaseService, InitializeDatabaseService>();
}