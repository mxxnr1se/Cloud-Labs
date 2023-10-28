using AutoMapper;
using BLL.DTOs.User;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using DAL.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Roles;
using InvalidDataException = BLL.Exceptions.InvalidDataException;
using Task = System.Threading.Tasks.Task;
using TaskStatus = Shared.Enums.TaskStatus;

namespace BLL.Services.Realizations;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUoW _uow;

    public UserService(IUoW uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    /// <summary>
    ///     Gives an info about users in project
    /// </summary>
    /// <param name="userId">User id of person who wants to do this action</param>
    /// <param name="projectId">Project id for which one gets users</param>
    /// <returns>List of users</returns>
    /// <exception cref="Exceptions.InvalidDataException">Throws when user id is invalid</exception>
    /// <exception cref="DbQueryResultNullException">Throws when project wasn't found by id</exception>
    public async Task<IEnumerable<UserOfProjectDto>> GetUsersOfProjectAsync(int projectId, int userId)
    {
        var project = await _uow.Projects.GetByIdAsync(projectId);

        if (project == null)
            throw new DbQueryResultNullException("No project with this id");

        if (project.Users.All(user => user.Id != userId))
            throw new IdentityException("Only manager of this project can get them");

        return _mapper.Map<IEnumerable<UserOfProjectDto>>(project.Users);
    }

    /// <summary>
    ///     Gives an info about users, if they are in project
    /// </summary>
    /// <param name="userId">User id of person who wants to do this action</param>
    /// <param name="projectId">Project id for which one gets users</param>
    /// <returns>List of users</returns>
    /// <exception cref="Exceptions.InvalidDataException">Throws when user id is invalid</exception>
    /// <exception cref="DbQueryResultNullException">Throws when project wasn't found by id</exception>
    public async Task<IEnumerable<UserIsInProjectDto>> GetUsersForProjectUsersAsync(int projectId, int userId)
    {
        var project = await _uow.Projects.GetByIdAsync(projectId);

        if (project == null)
            throw new DbQueryResultNullException("No project with this id");

        if (project.Users.All(user => user.Id != userId))
            throw new IdentityException("Only manager of this project can remove it");

        var usersInProject = await _uow.UserManager.Users
                                       .Where(u => u.Projects.Any(p => p.Id == projectId)).ToListAsync();

        var usersNotInProject = await _uow.UserManager.Users
                                          .Where(u => u.Projects.All(p => p.Id != projectId)).ToListAsync();

        return await GetUsersForProjectManagement(usersInProject, usersNotInProject);
    }

    /// <summary>
    ///     Gives an info about users and managers, for changing their roles later
    /// </summary>
    /// <returns>List of users with roles</returns>
    public async Task<IEnumerable<UserRoleDto>> GetUsersAndManagersAsync()
    {
        var users = await _uow.UserManager.Users.ToListAsync();
        var usersAndManagers = new List<UserRoleDto>();

        foreach (var user in users)
        {
            var roles = await _uow.UserManager.GetRolesAsync(user);
            if (roles[0] == RoleTypes.User || roles[0] == RoleTypes.Manager)
                usersAndManagers.Add(new UserRoleDto
                {
                        FullName = $"{user.Surname} {user.FirstName}",
                        Id = user.Id,
                        Role = roles[0]
                });
        }

        return usersAndManagers;
    }

    /// <summary>
    ///     Gives user by id
    /// </summary>
    /// <param name="id">Id of the user</param>
    /// <returns>User</returns>
    /// <exception cref="Exceptions.InvalidDataException">Throws when id is invalid</exception>
    /// <exception cref="DbQueryResultNullException">Throws when user wasn't found by id</exception>
    public async Task<UserDto> GetByIdAsync(int id)
    {
        if (id <= 0)
            throw new InvalidDataException("Value of id must be positive");

        var user = await _uow.UserManager.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
            throw new DbQueryResultNullException("This user wasn't found");

        return _mapper.Map<UserDto>(user);
    }

    /// <summary>
    ///     Sets new role to user
    /// </summary>
    /// <param name="userRoleDto">User info and role to set</param>
    /// <exception cref="DbQueryResultNullException">Throws if role is invalid</exception>
    /// <exception cref="Exceptions.InvalidDataException">
    ///     Throws when user id is invalid or user is in this role already, or changes
    ///     wasn't saved
    /// </exception>
    public async Task SetUserRoleAsync(UserRoleDto userRoleDto)
    {
        var user = await _uow.UserManager.Users.FirstOrDefaultAsync(u => u.Id == userRoleDto.Id);

        if (user == null)
            throw new DbQueryResultNullException("User doesn't exist");

        if (!string.Equals(userRoleDto.Role, RoleTypes.User) && !string.Equals(userRoleDto.Role, RoleTypes.Manager))
            throw new InvalidDataException("User role is invalid");

        if (await _uow.UserManager.IsInRoleAsync(user, userRoleDto.Role))
            throw new InvalidDataException("User is in this role already");

        var userRoles = await _uow.UserManager.GetRolesAsync(user);
        await _uow.UserManager.RemoveFromRolesAsync(user, userRoles);
        await _uow.UserManager.AddToRoleAsync(user, userRoleDto.Role);

        var result = await _uow.UserManager.UpdateAsync(user);

        if (!result.Succeeded)
            throw new InvalidDataException(result.Errors?.FirstOrDefault()?.Description);
    }

    /// <summary>
    ///     Changes user info
    /// </summary>
    /// <param name="userDto">User info</param>
    /// <param name="userId">User id of person who wants to do this action</param>
    /// <exception cref="DbQueryResultNullException">Throws when user doesn't exist</exception>
    /// <exception cref="IdentityException">Throws when another user tries to change info about current user</exception>
    /// <exception cref="Exceptions.InvalidDataException">Throws when user data is invalid</exception>
    public async Task UpdateAsync(UserDto userDto, int userId)
    {
        if (userDto.Id != userId)
            throw new IdentityException("Only this user can update his data");

        var user = await _uow.UserManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
            throw new DbQueryResultNullException("User doesn't exist");

        user.FirstName = userDto.FirstName;
        user.Surname = userDto.Surname;
        user.Email = userDto.Email;
        user.UserName = userDto.UserName;

        var result = await _uow.UserManager.UpdateAsync(user);

        if (!result.Succeeded)
            throw new InvalidDataException(result.Errors?.FirstOrDefault()?.Description);
    }

    /// <summary>
    ///     Removes user
    /// </summary>
    /// <returns>User info</returns>
    /// <param name="id">User id to remove</param>
    /// <exception cref="DbQueryResultNullException">Throws when user doesn't exist</exception>
    /// <exception cref="Exceptions.InvalidDataException">Throws when user id is invalid</exception>
    public async Task<UserDto> DeleteByIdAsync(int id)
    {
        var user = await _uow.UserManager.Users.Include(u => u.Tasks)
                             .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
            throw new DbQueryResultNullException("User doesn't exist");

        foreach (var task in user.Tasks)
        {
            task.UserId = null;
            if (task.TaskStatus == TaskStatus.InProgress)
                task.TaskStatus = TaskStatus.Open;
        }

        await _uow.UserManager.DeleteAsync(user);
        return _mapper.Map<UserDto>(user);
    }

    /// <summary>
    ///     Removes user
    /// </summary>
    /// <returns>List of users</returns>
    /// <param name="usersInProject">Users that are in project</param>
    /// <param name="usersNotInProject">Users that aren't in project</param>
    private async Task<IEnumerable<UserIsInProjectDto>> GetUsersForProjectManagement(
            IEnumerable<User> usersInProject, IEnumerable<User> usersNotInProject)
    {
        var users = new List<UserIsInProjectDto>();

        foreach (var user in usersInProject)
        {
            if (await _uow.UserManager.IsInRoleAsync(user, RoleTypes.User))
                users.Add(new UserIsInProjectDto
                {
                        UserId = user.Id,
                        FullName = user.FirstName + " " + user.Surname,
                        IsInProject = true
                });
        }

        foreach (var user in usersNotInProject)
        {
            if (await _uow.UserManager.IsInRoleAsync(user, RoleTypes.User))
                users.Add(new UserIsInProjectDto
                {
                        UserId = user.Id,
                        FullName = user.FirstName + " " + user.Surname,
                        IsInProject = false
                });
        }

        return users.ToArray();
    }
}