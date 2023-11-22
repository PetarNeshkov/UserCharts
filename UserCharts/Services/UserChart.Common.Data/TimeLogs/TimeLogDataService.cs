using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using UserChart.Data.Common;
using UserChart.UI.Models.UserCharts;
using UsersChart.Data;
using UsersChart.Data.Models;

namespace UserChart.Data.TimeLogs;

public class TimeLogDataService : DataService<TimeLog>, ITimeLogDataService
{
    private readonly IMapper mapper;

    public TimeLogDataService(UsersChartDbContext db, IMapper mapper)
        : base(db)
    {
        this.mapper = mapper;
    }
    
    public async Task<IEnumerable<TServiceModel>> GetCurrentTimeLogs<TServiceModel>(
        int page,
        DateTime? dateFrom,
        DateTime? dateTo)
    {
        var skip = (page - 1) * 10;

        var timeLogsQueryable = GetQuery();
        if (dateFrom != null)
        {
            timeLogsQueryable =  GetQuery(
                filter: t => t.Date > dateFrom,
                orderBy: t => t.Id,
                descending: false,
                skip,
                take: 10);
        }

        if (dateTo != null)
        {
            timeLogsQueryable =  GetQuery(
                filter: t => t.Date < dateTo,
                orderBy: t => t.Id,
                descending: false,
                skip,
                take: 10);
        }
        
        return await timeLogsQueryable
            .ProjectTo<TServiceModel>(mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<int> GetTimeLogsCount()
        => await GetQuery().CountAsync();

    public async Task<IEnumerable<UsersChartListingModel>> GetCurrentTopUsers(DateTime? dateFrom, DateTime? dateTo)
    {
        var topUserQueryable = GetQuery();
        
        if (dateFrom != null)
        {
            topUserQueryable =  GetQuery(
                filter: t => t.Date > dateFrom);
        }

        if (dateTo != null)
        {
            topUserQueryable =  GetQuery(
                filter: t => t.Date < dateTo);
        }

        return  await topUserQueryable
            .GroupBy(t => t.UserId)
            .Select(u => new UsersChartListingModel
            {
                KeyNameValue = u.Select(u => u.User.FirstName + u.User.LastName).FirstOrDefault(),
                HoursWorked = u.Sum(u => u.HoursWorked)
            })
            .OrderByDescending(u => u.HoursWorked)
            .Take(10)
            .ToListAsync();
    }

    public async Task<IEnumerable<UsersChartListingModel>> GetCurrentTopProjects(DateTime? dateFrom, DateTime? dateTo)
    {
        var topUserQueryable = GetQuery();
        
        if (dateFrom != null)
        {
            topUserQueryable =  GetQuery(
                filter: t => t.Date > dateFrom);
        }

        if (dateTo != null)
        {
            topUserQueryable =  GetQuery(
                filter: t => t.Date < dateTo);
        }

        return await topUserQueryable
            .GroupBy(t => t.ProjectId)
            .Select(u => new UsersChartListingModel
            {
                KeyNameValue = u.Select(u => u.Project.Name).FirstOrDefault(),
                HoursWorked = u.Sum(u => u.HoursWorked)
            })
            .OrderByDescending(u => u.HoursWorked)
            .Take(10)
            .ToListAsync();
    }
}