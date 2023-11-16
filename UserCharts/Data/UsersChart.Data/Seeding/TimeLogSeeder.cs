using Bogus;
using UsersChart.Data.Models;
using UsersChart.Data.Seeding.Common;

using static UsersChart.Data.Seeding.Common.SeederConstant.TimeLog;

namespace UsersChart.Data.Seeding;

public class TimeLogSeeder : ISeeder
{
    public async Task SeedAsync(UsersChartDbContext dbContext, IServiceProvider serviceProvider)
    {
        var random = new Random();

        var timeLogFaker = new Faker<TimeLog>()
            .RuleFor(tl => tl.UserId, f => f.PickRandom(dbContext.Users.Select(u => u.Id).ToList()))
            .RuleFor(tl => tl.ProjectId, f => f.PickRandom(dbContext.Projects.Select(p => p.Id).ToList()))
            .RuleFor(tl => tl.Date, f => f.Date.Recent())
            .RuleFor(tl => tl.HoursWorked, (f, u) => {
                var totalRandomMinutes = f.Random.Number(MinWorkingMinutes, MaxWorkingMinutes);
                
                var totalTime = TimeSpan.FromMinutes(totalRandomMinutes).ToString(@"hh\.mm");
                
                return float.Parse(totalTime);
            });

        var randomGeneratedCount = random.Next(MinNumberEntries, MaxNumberEntries);

        var timeLogs = timeLogFaker.Generate(randomGeneratedCount);

        await dbContext.TimeLogs.AddRangeAsync(timeLogs);
    }
}