using UserChart.UI.Models.TimeLogs;

namespace UserChart.Business.TimeLogs;

public interface ITimeLogService
{
    Task<IEnumerable<TimeLogsListingModel>> GetUserTimeLogs(TimeLogServiceModel timeLogService);
    
    Task<int> GetTimeLogsCount();
    
}