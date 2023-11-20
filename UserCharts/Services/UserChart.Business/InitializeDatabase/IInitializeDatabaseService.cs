using UserChart.UI.Models.TimeLogs;

namespace UserChart.Business.InitializeDatabase;

public interface IInitializeDatabaseService
{
    Task InitializeDatabase();
}