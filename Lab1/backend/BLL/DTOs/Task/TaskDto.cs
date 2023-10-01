using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BLL.DTOs.Task;

public class TaskDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required and shouldn't be null")]
    [NotNull]
    public string Name { get; set; }

    [Required(ErrorMessage = "Description is required and shouldn't be null")]
    [NotNull]
    public string Description { get; set; }

    public string CreationDate { get; set; }
    public string LastUpdate { get; set; }
    public string Deadline { get; set; }
    public string TaskStatus { get; set; }

    [Required(ErrorMessage = "TaskStatusId is required")]
    public int TaskStatusId { get; set; }

    public string TaskPriority { get; set; }

    [Required(ErrorMessage = "TaskPriorityId is required")]
    public int TaskPriorityId { get; set; }

    [Required(ErrorMessage = "ProjectId is required")]
    public int ProjectId { get; set; }

    public int? UserId { get; set; }
}