using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BLL.DTOs.Project;

public class ProjectDto
{
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required and shouldn't be null")]
    [NotNull]
    public string Name { get; set; }

    [Required(ErrorMessage = "Description is required and shouldn't be null")]
    [NotNull]
    public string Description { get; set; }
}