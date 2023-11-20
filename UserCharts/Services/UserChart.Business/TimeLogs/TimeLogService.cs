using UserChart.Data.TimeLogs;
using UserChart.UI.Models.TimeLogs;

namespace UserChart.Business.TimeLogs;

public class TimeLogService : ITimeLogService
{
    private readonly ITimeLogDataService timeLogData;

    public TimeLogService(ITimeLogDataService timeLogData)
    {
        this.timeLogData = timeLogData;
    }
    
    public async Task<IEnumerable<TimeLogsServiceModel>> GetUserTimeLogs()
    {
        return await timeLogData.GetCurrentTimeLogs<TimeLogsServiceModel>();
    }
}