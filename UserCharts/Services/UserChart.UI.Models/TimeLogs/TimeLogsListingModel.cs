
namespace UserChart.UI.Models.TimeLogs;

public class TimeLogsListingModel 
{
    public int Id { get; init; }
    
    public string Username { get; init; }
    
    public string Email { get; init; }
    
    public string ProjectName { get; init; }
    
    public DateTime Date { get; init; }
    
    public float HoursWorked { get; init; }
    
}