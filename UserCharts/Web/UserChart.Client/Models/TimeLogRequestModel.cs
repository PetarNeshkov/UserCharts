namespace UserChart.Client.Models;

public class TimeLogRequestModel
{
    public int Page { get; init; }
    
    public DateTime? From { get; init; }
    
    public DateTime? To { get; init; }
}