using UserChart.UI.Models.TimeLogs;

namespace UserChart.Business.TimeLogs;

public interface ITimeLogService
{
    Task<IEnumerable<TimeLogsServiceModel>> GetUserTimeLogs();
}