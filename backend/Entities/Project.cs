namespace Entities;

public class Project : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<User> Users { get; set; }
    public ICollection<Task> Tasks { get; set; }
}