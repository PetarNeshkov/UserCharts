namespace UserChart.Data.TimeLogs;

public interface ITimeLogDataService
{
    Task<IEnumerable<TServiceModel>> GetCurrentTimeLogs<TServiceModel>(int page, DateTime? dateFrom, DateTime? dateTo);
    
    Task<int> GetTimeLogsCount();
    
}