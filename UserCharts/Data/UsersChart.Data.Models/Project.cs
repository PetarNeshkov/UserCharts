using System.ComponentModel.DataAnnotations;
using UsersChart.Data.Models.Common;

namespace UsersChart.Data.Models;

public class Project : BaseModel<int>
{
    [Required]
    public string Name { get; set; }

    public ICollection<TimeLog> TimeLogs { get; set; } = new List<TimeLog>();
}