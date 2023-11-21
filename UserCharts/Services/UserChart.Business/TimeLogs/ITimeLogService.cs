using UserChart.UI.Models.TimeLogs;
using UserChart.UI.Models.UserCharts;

namespace UserChart.Business.TimeLogs;

public interface ITimeLogService
{
    Task<IEnumerable<TimeLogsListingModel>> GetUserTimeLogs(TimeLogServiceModel timeLogService);
    
    Task<int> GetTimeLogsCount();

    Task<IEnumerable<UsersChartListingModel>> GetTopUsers(UsersChartServiceModel usersChartService);

}