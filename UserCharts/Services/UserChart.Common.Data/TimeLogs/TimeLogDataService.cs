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

    public async Task<IEnumerable<TServiceModel>> GetCurrentTimeLogs<TServiceModel>()
        => await GetQuery()
            .ProjectTo<TServiceModel>(mapper.ConfigurationProvider)
            .ToListAsync();

}