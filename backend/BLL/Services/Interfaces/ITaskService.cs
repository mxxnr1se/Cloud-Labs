using BLL.DTOs.Task;

namespace BLL.Services.Interfaces;

public interface ITaskService
{
    Task<TasksOfProject> GetAllTasksByProjectIdAsync(int projectId, int userId);
    Task<TaskDto> GetByIdAsync(int id, int userId);
    Task<TaskDto> CreateAsync(TaskDto taskDto, int userId);
    Task UpdateAsync(TaskDto taskDto, int userId);
    Task<int> RemoveAsync(int taskId, int userId);
}