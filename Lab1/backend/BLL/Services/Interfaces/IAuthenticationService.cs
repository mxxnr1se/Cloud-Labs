using BLL.DTOs.User;

namespace BLL.Services.Interfaces;

public interface IAuthenticationService
{
    Task<string> SignInAsync(LoginDto loginDto);
    Task<UserDto> SignUpAsync(RegistrationDto registrationDto);
}