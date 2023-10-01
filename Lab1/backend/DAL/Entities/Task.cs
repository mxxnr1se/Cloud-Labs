using Shared.Enums;
using TaskStatus = Shared.Enums.TaskStatus;

namespace DAL.Entities;

public class Task : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastUpdate { get; set; }
    public DateTime Deadline { get; set; }
    public TaskStatus TaskStatus { get; set; }
    public TaskPriority TaskPriority { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; }

    public int? UserId { get; set; }
    public User? User { get; set; }
}