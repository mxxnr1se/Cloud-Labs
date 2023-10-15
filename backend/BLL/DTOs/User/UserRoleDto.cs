using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BLL.DTOs.User;

public class UserRoleDto
{
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; }

    [Required(ErrorMessage = "FullName is required and shouldn't be null")]
    [NotNull]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Role is required and shouldn't be null")]
    [NotNull]
    public string Role { get; set; }
}