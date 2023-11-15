using System.ComponentModel.DataAnnotations;

namespace UsersChart.Data.Models.Common;

public abstract class BaseModel<TKey>
{
    [Key] 
    public TKey Id { get; init; }
}