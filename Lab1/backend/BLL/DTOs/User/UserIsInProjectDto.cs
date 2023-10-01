namespace BLL.DTOs.User;

public class UserIsInProjectDto
{
    public int UserId { get; set; }
    public string FullName { get; set; }
    public bool IsInProject { get; set; }
}