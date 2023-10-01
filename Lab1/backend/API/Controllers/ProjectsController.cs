using System.Security.Claims;
using BLL.DTOs.Project;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Roles;

namespace API.Controllers;

/// <summary>
///     <c>ProjectsController</c> is a class.
///     Contains all http methods for working with projects.
/// </summary>
/// <remarks>
///     This class can return, create, remove, edit projects, add users to them, return statistics about tasks in project.
/// </remarks>
/// <response code="400">Returns message if something had gone wrong</response>
/// <response code="401">If token is invalid or it wasn't provided</response>
/// <response code="403">If user doesn't have needed credentials</response>

// api/projects
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProjectsController : ControllerBase
{
    private readonly ILogger<ProjectsController> _logger;
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService, ILogger<ProjectsController> logger)
    {
        _projectService = projectService;
        _logger = logger;
    }

    /// <summary>
    ///     This method returns all projects
    /// </summary>
    /// <response code="200">Returns all projects</response>

    //GET api/projects
    [Authorize(Roles = RoleTypes.Admin)]
    [HttpGet]
    public async Task<ActionResult> GetAllProjects()
    {
        int userId = Convert.ToInt32(User.FindFirstValue("UserId"));
        _logger.LogInformation("Admin with Id {UserId} got all projects list", userId);

        var projects = await _projectService.GetAllProjectsAsync();

        return Ok(projects);
    }

    /// <summary>
    ///     This method returns all projects for current user
    /// </summary>
    /// <response code="200">Returns all projects for current user</response>
    /// <response code="404">Returns message that nothing was found</response>

    //GET api/projects/current-user
    [HttpGet("current-user")]
    public async Task<IActionResult> GetAllProjectsByUser()
    {
        int userId = Convert.ToInt32(User.FindFirstValue("UserId"));

        var projects = await _projectService.GetAllProjectsByUserIdAsync(userId);

        if (!projects.Any())
            return NotFound();
        return Ok(projects);
    }

    /// <summary>
    ///     This method returns project that has an inputted Id property
    /// </summary>
    /// <response code="200">Returns project that has an inputted Id property</response>

    //GET api/projects/{id}
    [HttpGet("{id:int}", Name = "GetProjectById")]
    public async Task<IActionResult> GetProjectById(int id)
    {
        var project = await _projectService.GetByIdAsync(id);

        return Ok(project);
    }

    /// <summary>
    ///     This method returns project that was created and path to it
    /// </summary>
    /// <response code="201">Returns project that was created and path to it</response>

    //POST api/projects
    [Authorize(Roles = RoleTypes.Manager)]
    [HttpPost]
    [ProducesResponseType(typeof(ProjectDto), 201)]
    public async Task<IActionResult> CreateProject(ProjectCreateDto projectDto)
    {
        int userId = Convert.ToInt32(User.FindFirstValue("UserId"));
        _logger.LogInformation("Manager with Id {UserId} wants to create project", userId);

        var createdProject = await _projectService.CreateAsync(projectDto, userId);
        _logger.LogInformation("Manager with Id {UserId} created project with id {ProjectId}",
                               userId, createdProject.Id);

        //Fetch the project from data source
        return CreatedAtRoute("GetProjectById", new { id = createdProject.Id }, createdProject);
    }

    /// <summary>
    ///     This method changes project
    /// </summary>
    /// <response code="204">Returns nothing, project was successfully changed</response>

    //PUT api/projects
    [Authorize(Roles = RoleTypes.Manager)]
    [HttpPut]
    [ProducesResponseType(204)]
    public async Task<IActionResult> UpdateProject(ProjectDto projectDto)
    {
        int userId = Convert.ToInt32(User.FindFirstValue("UserId"));
        _logger.LogInformation("Manager with Id {UserId} wants to change project with id {ProjectId}",
                               userId, projectDto.Id);

        await _projectService.UpdateAsync(projectDto, userId);

        _logger.LogInformation("Manager with Id {UserId} changed project with id {ProjectId} successfully",
                               userId, projectDto.Id);

        return NoContent();
    }

    /// <summary>
    ///     This method removes project
    /// </summary>
    /// <response code="204">Returns nothing, project was successfully removed</response>
    /// <response code="404">Returns message that project was not found</response>

    //DELETE api/projects/{id}
    [Authorize(Roles = RoleTypes.Manager)]
    [HttpDelete("{id:int}")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> RemoveProject(int id)
    {
        int userId = Convert.ToInt32(User.FindFirstValue("UserId"));
        _logger.LogInformation("Manager with Id {UserId} wants to remove project with id {ProjectId}",
                               userId, id);

        await _projectService.RemoveAsync(id, userId);
        _logger.LogInformation(
                "Manager with Id {UserId} removed project with id {ProjectId} and all its tasks successfully",
                userId, id);

        return NoContent();
    }

    /// <summary>
    ///     This method adds user to project and sends email to this person
    /// </summary>
    /// <response code="204">Returns nothing, user was successfully added to project</response>

    //POST api/projects/add-user-to-project
    [Authorize(Roles = RoleTypes.Manager)]
    [HttpPost("add-user-to-project")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> AddUserToProject(UserToProjectDto userToProjectDto)
    {
        int userId = Convert.ToInt32(User.FindFirstValue("UserId"));
        _logger.LogInformation(
                "Manager with Id {UserId} wants to add user with Id {Id} to project with Id {ProjectId}",
                userId, userToProjectDto.UserId, userToProjectDto.ProjectId);

        await _projectService.AddUserToProjectAsync(userToProjectDto, userId);
        _logger.LogInformation(
                "Manager with Id {UserId} added user with Id {Id} to project with Id {ProjectId} successfully",
                userId, userToProjectDto.UserId, userToProjectDto.ProjectId);

        return NoContent();
    }

    /// <summary>
    ///     This method remove user from project and sends email to this person
    /// </summary>
    /// <response code="204">Returns nothing, user was successfully removed from project</response>

    //POST api/projects/remove-user-from-project
    [Authorize(Roles = RoleTypes.Manager)]
    [HttpPost("remove-user-from-project")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> RemoveUserToProject(UserToProjectDto userToProjectDto)
    {
        int userId = Convert.ToInt32(User.FindFirstValue("UserId"));
        _logger.LogInformation(
                "Manager with Id {UserId} wants to remove user with Id {Id} from project with Id {ProjectId}",
                userId, userToProjectDto.UserId, userToProjectDto.ProjectId);

        await _projectService.RemoveUserFromProjectAsync(userToProjectDto, userId);
        _logger.LogInformation(
                "Manager with Id {UserId} removed user with Id {Id} from project with Id {ProjectId} successfully",
                userId, userToProjectDto.UserId, userToProjectDto.ProjectId);

        return NoContent();
    }
}