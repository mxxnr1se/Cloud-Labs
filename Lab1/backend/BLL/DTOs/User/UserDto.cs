using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BLL.DTOs.User;

public class UserDto
{
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; }

    [Required(ErrorMessage = "FirstName is required and shouldn't be null")]
    [NotNull]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Surname is required and shouldn't be null")]
    [NotNull]
    public string Surname { get; set; }

    [Required(ErrorMessage = "UserName is required and shouldn't be null")]
    [NotNull]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Email is required and shouldn't be null")]
    [NotNull]
    public string Email { get; set; }
}