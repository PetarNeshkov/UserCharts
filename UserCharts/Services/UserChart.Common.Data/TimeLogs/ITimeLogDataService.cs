namespace UserChart.Data.TimeLogs;

public interface ITimeLogDataService
{
    Task<IEnumerable<TServiceModel>> GetCurrentTimeLogs<TServiceModel>();
}