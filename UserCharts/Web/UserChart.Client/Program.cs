using UserChart.Client;
using UsersChart.Web;
using UsersChart.Web.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddDatabase(builder.Configuration)
    .AddAutoMapper(typeof(MappingProfiler))
    .AddApplicationServices(builder.Configuration)
    .AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app
    .PrepareDatabase()
    .UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting()
    .UseAnyCors()
    .UseEndpoints();
    
    
    
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapFallbackToFile("index.html");


app.Run();