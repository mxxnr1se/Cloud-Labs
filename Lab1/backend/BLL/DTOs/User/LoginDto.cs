using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BLL.DTOs.User;

public class LoginDto
{
    [Required(ErrorMessage = "UserName is required and shouldn't be null")]
    [NotNull]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Password is required and shouldn't be null")]
    [NotNull]
    public string Password { get; set; }
}