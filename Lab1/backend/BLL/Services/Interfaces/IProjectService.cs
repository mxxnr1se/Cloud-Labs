using BLL.DTOs.Project;

namespace BLL.Services.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectDto>> GetAllProjectsAsync();
    Task<IEnumerable<ProjectDto>> GetAllProjectsByUserIdAsync(int userId);
    Task<ProjectDto> GetByIdAsync(int id);
    Task<ProjectDto> CreateAsync(ProjectCreateDto projectDto, int userId);
    Task UpdateAsync(ProjectDto projectDto, int userId);
    Task RemoveAsync(int projectId, int userId);
    Task AddUserToProjectAsync(UserToProjectDto userToProjectDto, int userId);
    Task RemoveUserFromProjectAsync(UserToProjectDto userToProjectDto, int userId);
}