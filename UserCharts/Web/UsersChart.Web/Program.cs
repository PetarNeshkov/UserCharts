using UsersChart.Web.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSwaggerGen()
    .AddEndpointsApiExplorer()
    .AddDatabase(builder.Configuration)
    .AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app
    .UseHttpsRedirection()
    .UseAuthorization();

app.MapControllers();
app.Run();
