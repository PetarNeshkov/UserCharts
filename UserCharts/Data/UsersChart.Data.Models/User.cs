using System.ComponentModel.DataAnnotations;
using UsersChart.Data.Models.Common;

namespace UsersChart.Data.Models;

public class User : BaseModel<string>
{
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }

    public ICollection<TimeLog> TimeLogs { get; set; } = new List<TimeLog>();
}