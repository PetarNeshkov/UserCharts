using UsersChart.Data.Models.Common;

namespace UsersChart.Data.Models;

public class TimeLog : BaseModel<int>
{
    public string UserId { get; set; }
    
    public User User { get; set; }
    
    public int ProjectId { get; set; }
    
    public Project Project { get; set; }
    
    public DateTime Date { get; set; }
    
    public float HoursWorked { get; set; }
}