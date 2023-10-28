using AutoMapper;
using BLL.DTOs.Task;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Enums;
using Shared.Roles;
using InvalidDataException = BLL.Exceptions.InvalidDataException;
using TaskStatus = Shared.Enums.TaskStatus;

namespace BLL.Services.Realizations;

public class TaskService : ITaskService
{
    private readonly IMapper _mapper;
    private readonly IUoW _uow;

    public TaskService(IUoW uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    /// <summary>
    ///     Gives all tasks of project
    /// </summary>
    /// <param name="userId">User id of person who wants to do this action</param>
    /// <param name="projectId">Project id</param>
    /// <returns>List of tasks</returns>
    /// <exception cref="Exceptions.InvalidDataException">Throws when user id is invalid</exception>
    /// <exception cref="DbQueryResultNullException">Throws when project wasn't find by id</exception>
    public async Task<TasksOfProject> GetAllTasksByProjectIdAsync(int projectId, int userId)
    {
        if (userId == 0)
            throw new InvalidDataException("Value of UserId in token can't be null or empty");

        var user = await _uow.UserManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
            throw new DbQueryResultNullException("User doesn't exist");

        if (projectId <= 0)
            throw new InvalidDataException("Value of projectId must be positive");

        var project = await _uow.Projects.GetByIdAsync(projectId);

        if (project == null)
            throw new DbQueryResultNullException("This project wasn't found");

        if (project.Users.All(u => u.Id != userId))
            throw new IdentityException("Only user of this project can get them");

        var projectTasks = project.Tasks.ToList();

        if (await _uow.UserManager.IsInRoleAsync(user, RoleTypes.Manager))
            return new TasksOfProject
            {
                    Tasks = _mapper.Map<IEnumerable<TaskDto>>(project.Tasks),
                    PercentageOfCompletion =
                            Math.Round(projectTasks.Count(t => t.TaskStatus is TaskStatus.Completed)
                                       / (double)project.Tasks.Count(t => t.TaskStatus != TaskStatus.Cancelled),
                                       4) * 100
            };

        return new TasksOfProject
        {
                Tasks = _mapper.Map<IEnumerable<TaskDto>>(project.Tasks.Where(t => t.UserId == userId)),
                PercentageOfCompletion =
                        Math.Round(projectTasks.Count(
                                           t => t.TaskStatus is TaskStatus.Completed && t.UserId == userId)
                                   / (double)project.Tasks.Count(
                                           t => t.UserId == userId && t.TaskStatus != TaskStatus.Cancelled), 4) *
                        100
        };
    }

    /// <summary>
    ///     Gives task by id
    /// </summary>
    /// <param name="id">Id of the task</param>
    /// <param name="userId">User id of person who wants to do this action</param>
    /// <returns>Task</returns>
    /// <exception cref="Exceptions.InvalidDataException">Throws when id is invalid</exception>
    /// <exception cref="IdentityException">Throws when user is not a manager or user of this task</exception>
    /// <exception cref="DbQueryResultNullException">Throws when user or task weren't found</exception>
    public async Task<TaskDto> GetByIdAsync(int id, int userId)
    {
        if (userId == 0)
            throw new InvalidDataException("Value of UserId in token can't be null or empty");

        var user = await _uow.UserManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null)
            throw new DbQueryResultNullException("User doesn't exist");

        if (id <= 0)
            throw new InvalidDataException("Value of task id must be positive");

        var task = await _uow.Tasks.GetByIdAsync(id);

        if (task == null)
            throw new DbQueryResultNullException("This task wasn't found");

        if (await _uow.UserManager.IsInRoleAsync(user, RoleTypes.Manager) || userId == task.Id)
            return _mapper.Map<TaskDto>(task);

        throw new IdentityException("Only user or manager of this task can get it");
    }

    /// <summary>
    ///     Adds new project
    /// </summary>
    /// <param name="taskDto">Task</param>
    /// <param name="userId">User id of person who wants to do this action</param>
    /// <exception cref="DbQueryResultNullException">Throws when task wasn't saved or project doesn't exist</exception>
    /// <exception cref="IdentityException">Throws when user is not a manager of this project</exception>
    /// <exception cref="Exceptions.InvalidDataException">Throws when data is invalid</exception>
    public async Task<TaskDto> CreateAsync(TaskDto taskDto, int userId)
    {
        if (userId == 0)
            throw new InvalidDataException("Value of UserId in token can't be null or empty");

        var project = await _uow.Projects.GetByIdAsync(taskDto.ProjectId);

        if (project == null)
            throw new DbQueryResultNullException("This project wasn't found");

        if (project.Users.All(u => u.Id != userId))
            throw new IdentityException("Only manager of this project can add new task");

        if (!Enum.IsDefined(typeof(TaskStatus), taskDto.TaskStatusId))
            throw new InvalidDataException("Incorrect TaskStatusId");

        if (!Enum.IsDefined(typeof(TaskPriority), taskDto.TaskPriorityId))
            throw new InvalidDataException("Incorrect TaskPriorityId");

        if (taskDto.UserId != null)
        {
            var user = await _uow.UserManager.Users.FirstOrDefaultAsync(u => u.Id == taskDto.UserId);
            if (user == null)
                throw new DbQueryResultNullException("User doesn't exist");
        }

        var task = _mapper.Map<Entities.Task>(taskDto);

        await _uow.Tasks.CreateAsync(task);

        if (!await _uow.SaveChangesAsync())
            throw new DbQueryResultNullException("This task wasn't created");

        return _mapper.Map<TaskDto>(task);
    }

    /// <summary>
    ///     Changes task info
    /// </summary>
    /// <param name="taskDto">Task</param>
    /// <param name="userId">User id of person who wants to do this action</param>
    /// <exception cref="DbQueryResultNullException">Throws when task wasn't saved or project doesn't exist</exception>
    /// <exception cref="IdentityException">Throws when user is not a manager of this project</exception>
    /// <exception cref="Exceptions.InvalidDataException">Throws when data is invalid</exception>
    public async Task UpdateAsync(TaskDto taskDto, int userId)
    {
        if (userId == 0)
            throw new InvalidDataException("Value of UserId in token can't be null or empty");

        if (!Enum.IsDefined(typeof(TaskStatus), taskDto.TaskStatusId))
            throw new InvalidDataException("Incorrect TaskStatusId");

        var user = await _uow.UserManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (user != null)
        {
            if (await _uow.UserManager.IsInRoleAsync(user, RoleTypes.User) && userId == taskDto.UserId)
            {
                var task = await _uow.Tasks.GetByIdAsync(taskDto.Id);

                if (task == null)
                    throw new DbQueryResultNullException("This task wasn't found");

                task.TaskStatus = (TaskStatus)taskDto.TaskStatusId;
                _uow.Tasks.Update(task);
            }
            else if (await _uow.UserManager.IsInRoleAsync(user, RoleTypes.Manager))
            {
                var project = await _uow.Projects.GetByIdAsync(taskDto.ProjectId);

                if (project == null)
                    throw new DbQueryResultNullException("This project wasn't found");

                if (project.Users.All(u => u.Id != userId))
                    throw new IdentityException("Only user of this project can add new task");

                if (!Enum.IsDefined(typeof(TaskPriority), taskDto.TaskPriorityId))
                    throw new InvalidDataException("Incorrect TaskPriorityId");

                if (taskDto.UserId != null)
                {
                    var userOfProject =
                            await _uow.UserManager.Users.FirstOrDefaultAsync(u => u.Id == taskDto.UserId);
                    if (userOfProject == null)
                        throw new DbQueryResultNullException("Can't assign task to person that doesn't exists");

                    if (project.Users.All(u => u.Id != userId))
                        throw new IdentityException(
                                "Can't assign task to person that doesn't exists in this project");
                }

                var task = await _uow.Tasks.GetByIdAsyncAsTracking(taskDto.Id);
                if (task == null)
                    throw new DbQueryResultNullException("This task wasn't found");

                var taskToUpdate = _mapper.Map<Entities.Task>(taskDto);

                task.Name = taskToUpdate.Name;
                task.Description = taskToUpdate.Description;
                task.Deadline = taskToUpdate.Deadline;
                task.LastUpdate = DateTime.Now;
                task.UserId = taskToUpdate.UserId;
                task.TaskStatus = (TaskStatus)taskDto.TaskStatusId;
                task.TaskPriority = (TaskPriority)taskDto.TaskPriorityId;

                _uow.Tasks.Update(task);
            }
        }

        if (!await _uow.SaveChangesAsync())
            throw new DbQueryResultNullException("This task wasn't updated");
    }

    /// <summary>
    ///     Removes project
    /// </summary>
    /// <param name="taskId">Task Id</param>
    /// <param name="userId">User id of person who wants to do this action</param>
    /// <exception cref="DbQueryResultNullException">Throws when task doesn't exist or removal wasn't produced</exception>
    /// <exception cref="IdentityException">Throws when user is not a manager of this project</exception>
    /// <exception cref="Exceptions.InvalidDataException">Throws when user id is invalid</exception>
    public async Task<int> RemoveAsync(int taskId, int userId)
    {
        if (userId == 0)
            throw new InvalidDataException("Value of UserId in token can't be null or empty");

        var task = await _uow.Tasks.GetByIdAsync(taskId);

        if (task == null)
            throw new DbQueryResultNullException("No record to remove from tasks");

        var project = await _uow.Projects.GetByIdAsync(task.ProjectId);

        if (project.Users.All(user => user.Id != userId))
            throw new IdentityException("Only manager of this project can remove it");

        _uow.Tasks.Remove(task);
        if (!await _uow.SaveChangesAsync())
            throw new DbQueryResultNullException("This task wasn't removed");

        return Convert.ToInt32(task.UserId);
    }
}