using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using UserChart.Data.Common;
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
}