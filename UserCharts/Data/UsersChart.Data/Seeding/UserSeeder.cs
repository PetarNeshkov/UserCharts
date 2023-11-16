using Bogus;
using UsersChart.Data.Models;
using UsersChart.Data.Seeding.Common;

using static UsersChart.Data.Seeding.Common.SeederConstant.User;


namespace UsersChart.Data.Seeding;

public class UserSeeder : ISeeder
{
    public async Task SeedAsync(UsersChartDbContext dbContext, IServiceProvider serviceProvider)
    {
        
        var userFaker = new Faker<User>()
            .RuleFor(u => u.Id, _ => Guid.NewGuid().ToString())
            .RuleFor(u => u.FirstName, f=> f.PickRandom(FirstNames))
            .RuleFor(u => u.LastName, f=> f.PickRandom(LastNames))
            .RuleFor(u => u.Email, (f,u) 
                =>  u.FirstName.ToLower() + u.LastName.ToLower() + "@" + f.PickRandom(EmailDomains));

        var users = userFaker.Generate(UsersCount);

        await dbContext.Users.AddRangeAsync(users);

    }
}