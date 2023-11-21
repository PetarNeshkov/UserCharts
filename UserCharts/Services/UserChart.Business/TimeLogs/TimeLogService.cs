using UserChart.Data.TimeLogs;
using UserChart.UI.Models.TimeLogs;
using UserChart.UI.Models.UserCharts;

namespace UserChart.Business.TimeLogs;

public class TimeLogService : ITimeLogService
{
    private readonly ITimeLogDataService timeLogData;

    public TimeLogService(ITimeLogDataService timeLogData)
    {
        this.timeLogData = timeLogData;
    }

    public async Task<IEnumerable<TimeLogsListingModel>> GetUserTimeLogs(TimeLogServiceModel timeLogService)
        => await timeLogData.GetCurrentTimeLogs<TimeLogsListingModel>(timeLogService.Page,timeLogService.From,timeLogService.To);

    public async Task<int> GetTimeLogsCount()
        => await timeLogData.GetTimeLogsCount();

    public async Task<IEnumerable<UsersChartListingModel>> GetTopUsers(UsersChartServiceModel usersChartService)
        => await timeLogData.GetCurrentTopUsers(usersChartService.From, usersChartService.To);
}