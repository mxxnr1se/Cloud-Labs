using System.Security.Claims;
using BLL.DTOs.Task;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Roles;

namespace taskservice.Controllers;

/// <summary>
///     <c>TasksController</c> is a class.
///     Contains all http methods for working with tasks.
/// </summary>
/// <remarks>
///     This class can return, create, remove, edit tasks, return statistics about them.
/// </remarks>
/// <response code="400">Returns message if something had gone wrong</response>
/// <response code="401">If token is invalid or it wasn't provided</response>
/// <response code="403">If user doesn't have needed credentials</response>

// api/tasks
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TasksController : ControllerBase
{
    private readonly ILogger<TasksController> _logger;
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService, ILogger<TasksController> logger)
    {
        _taskService = taskService;
        _logger = logger;
    }

    /// <summary>
    ///     This method returns task that has an inputted Id property
    /// </summary>
    /// <response code="200">Returns task that has an inputted Id property</response>

    //GET api/tasks/{id}
    [HttpGet("{id:int}", Name = "GetTaskById")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        int userId = Convert.ToInt32(User.FindFirstValue("UserId"));

        var task = await _taskService.GetByIdAsync(id, userId);

        return Ok(task);
    }

    /// <summary>
    ///     This method returns task that was created and path to it
    /// </summary>
    /// <response code="201">Returns task that was created and path to it</response>

    //POST api/tasks
    [Authorize(Roles = RoleTypes.Manager)]
    [HttpPost]
    [ProducesResponseType(typeof(TaskDto), 201)]
    public async Task<IActionResult> CreateTask(TaskDto taskDto)
    {
        int userId = Convert.ToInt32(User.FindFirstValue("UserId"));
        _logger.LogInformation("Manager with Id {UserId} wants to create task", userId);

        var createdTask = await _taskService.CreateAsync(taskDto, userId);
        _logger.LogInformation("Manager with Id {UserId} created task with id {TaskId}",
                               userId, createdTask.Id);

        //Fetch the task from data source
        return CreatedAtRoute("GetTaskById", new { id = createdTask.Id }, createdTask);
    }

    /// <summary>
    ///     This method changes task
    /// </summary>
    /// <response code="204">Returns nothing, task was successfully changed</response>

    //PUT api/tasks
    [Authorize(Roles = RoleTypes.User + "," + RoleTypes.Manager)]
    [HttpPut]
    [ProducesResponseType(204)]
    public async Task<IActionResult> UpdateTask(TaskDto taskDto)
    {
        int userId = Convert.ToInt32(User.FindFirstValue("UserId"));
        _logger.LogInformation("User with Id {UserId} wants to change task with id {TaskId}",
                               userId, taskDto.Id);

        await _taskService.UpdateAsync(taskDto, userId);

        _logger.LogInformation("User with Id {UserId} changed task with id {TaskId} successfully",
                               userId, taskDto.Id);

        return NoContent();
    }

    /// <summary>
    ///     This method returns tasks that has an inputted ProjectId property
    /// </summary>
    /// <response code="200">Returns tasks and percentage of completion that has an inputted ProjectId property</response>
    /// <response code="404">Returns message that nothing was found</response>

    //GET api/tasks/project/{id}
    [Authorize(Roles = RoleTypes.User + "," + RoleTypes.Manager)]
    [HttpGet("project/{id:int}")]
    public async Task<IActionResult> GetTasksByProjectId(int id)
    {
        int userId = Convert.ToInt32(User.FindFirstValue("UserId"));

        var tasks = await _taskService.GetAllTasksByProjectIdAsync(id, userId);

        if (!tasks.Tasks.Any())
            return NotFound();
        return Ok(tasks);
    }

    /// <summary>
    ///     This method removes task
    /// </summary>
    /// <response code="204">Returns nothing, task was successfully removed</response>
    /// <response code="404">Returns message that task was not found</response>

    //DELETE api/tasks/{id}
    [Authorize(Roles = RoleTypes.Manager)]
    [HttpDelete("{id:int}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> RemoveTask(int id)
    {
        int userId = Convert.ToInt32(User.FindFirstValue("UserId"));
        _logger.LogInformation("Manager with Id {UserId} wants to remove project task id {TaskId}",
                               userId, id);

        int taskUserId = await _taskService.RemoveAsync(id, userId);
        _logger.LogInformation(
                "Manager with Id {UserId} removed task with id {TaskId} and all its tasks successfully",
                userId, id);

        return NoContent();
    }
}