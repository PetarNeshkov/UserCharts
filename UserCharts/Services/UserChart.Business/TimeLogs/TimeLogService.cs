using UserChart.Data.TimeLogs;
using UserChart.UI.Models.TimeLogs;
using UserChart.UI.Models.UserCharts;

namespace UserChart.Business.TimeLogs;

public class TimeLogService : ITimeLogService
{
    private const string UsersOption = "users";
    private const string ProjectsOption = "projects";
    
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
    {
        if (usersChartService.SelectedOption == UsersOption )
        {
            return await timeLogData.GetCurrentTopUsers(usersChartService.From, usersChartService.To);
        }

        if (usersChartService.SelectedOption == ProjectsOption)
        {
            return await timeLogData.GetCurrentTopProjects(usersChartService.From, usersChartService.To);
        }

        return new List<UsersChartListingModel>();
    }

    public async Task<TimeLogUserModel> GetUserData(string userId)
        => await timeLogData.GetUserById<TimeLogUserModel>(userId);
}