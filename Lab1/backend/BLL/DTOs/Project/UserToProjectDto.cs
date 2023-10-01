using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.Project;

public class UserToProjectDto
{
    [Required(ErrorMessage = "ProjectId is required and shouldn't be null")]
    public int ProjectId { get; set; }

    [Required(ErrorMessage = "UserId is required and shouldn't be null")]
    public int UserId { get; set; }
}