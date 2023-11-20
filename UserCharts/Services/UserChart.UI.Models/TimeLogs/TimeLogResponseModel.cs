namespace UserChart.UI.Models.TimeLogs;

public class TimeLogResponseModel
{
    public IEnumerable<TimeLogsListingModel> TimeLog { get; set; }

    public int TotalItems { get; set; }
}