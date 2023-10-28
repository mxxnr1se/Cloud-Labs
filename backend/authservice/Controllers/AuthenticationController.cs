using BLL.DTOs.User;
using BLL.Services.Interfaces;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;

namespace authservice.Controllers;

/// <summary>
///     <c>AuthenticationController</c> is a class.
///     Contains all http methods for working with authentication.
/// </summary>
/// <remarks>
///     This class provides logging in and registration.
/// </remarks>
/// <response code="400">Returns message if something had gone wrong</response>

// api/authentication
[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly ILogger<AuthenticationController> _logger;

    public AuthenticationController(ILogger<AuthenticationController> logger,
                                    IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
        _logger = logger;
    }

    private readonly ProducerConfig config = new() { BootstrapServers = "kafka:9092" };
    private readonly string topic = "task_tracking_topic";

    private object SendToKafka(string topic, string message)
    {
        using (var producer = new ProducerBuilder<Null, string>(config).Build())
        {
            try
            {
                return producer.ProduceAsync(topic, new Message<Null, string> { Value = message })
                               .GetAwaiter()
                               .GetResult();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Oops, something went wrong: {e}");
            }
        }

        return null;
    }

    /// <summary>
    ///     This method for logging in
    /// </summary>
    /// <response code="200">Returns token</response>

    // api/authentication/login
    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginDto loginDto)
    {
        _logger.LogInformation("User with username {UserName} trying to sign in", loginDto.UserName);

        SendToKafka(topic, $"User with username {loginDto.UserName} trying to sign in");

        string token = await _authenticationService.SignInAsync(loginDto);

        _logger.LogInformation("User with username {UserName} signed in successfully", loginDto.UserName);

        return Ok(new { token });
    }

    /// <summary>
    ///     This method for registration
    /// </summary>
    /// <response code="204">Returns nothing, registration was successful</response>

    // api/authentication/registration
    [HttpPost("registration")]
    [ProducesResponseType(204)]
    public async Task<ActionResult> Register(RegistrationDto registrationDto)
    {
        var signedInUser = await _authenticationService.SignUpAsync(registrationDto);

        _logger.LogInformation("User with username {UserName} signed up successfully", signedInUser.UserName);

        return NoContent();
    }
}