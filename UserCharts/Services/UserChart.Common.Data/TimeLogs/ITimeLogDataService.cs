using UserChart.UI.Models.UserCharts;

namespace UserChart.Data.TimeLogs;

public interface ITimeLogDataService
{
    Task<IEnumerable<TServiceModel>> GetCurrentTimeLogs<TServiceModel>(int page, DateTime? dateFrom, DateTime? dateTo);
    
    Task<int> GetTimeLogsCount();

    Task<IEnumerable<UsersChartListingModel>> GetCurrentTopUsers(DateTime? dateFrom, DateTime? dateTo);
    
    Task<IEnumerable<UsersChartListingModel>> GetCurrentTopProjects(DateTime? dateFrom, DateTime? dateTo);


}