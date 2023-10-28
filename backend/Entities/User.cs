using Microsoft.AspNetCore.Identity;

namespace Entities;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string Surname { get; set; }

    public ICollection<Project> Projects { get; set; }
    public ICollection<Task> Tasks { get; set; }
}