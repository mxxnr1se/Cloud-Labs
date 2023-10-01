using BLL.DTOs.User;

namespace BLL.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserOfProjectDto>> GetUsersOfProjectAsync(int projectId, int userId);
    Task<IEnumerable<UserIsInProjectDto>> GetUsersForProjectUsersAsync(int projectId, int userId);
    Task<IEnumerable<UserRoleDto>> GetUsersAndManagersAsync();
    Task<UserDto> GetByIdAsync(int id);
    Task SetUserRoleAsync(UserRoleDto userRoleDto);
    Task UpdateAsync(UserDto user, int userId);
    Task<UserDto> DeleteByIdAsync(int id);
}