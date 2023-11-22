namespace UserChart.Client.Models;

public class UsersChartRequestModel
{
    public string SelectedOption { get; init; }
    
    public DateTime? From { get; init; }
    
    public DateTime? To { get; init; }
}