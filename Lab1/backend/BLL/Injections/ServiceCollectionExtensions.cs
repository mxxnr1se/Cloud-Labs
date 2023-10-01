using AutoMapper;
using BLL.Helpers;
using BLL.Services.Interfaces;
using BLL.Services.Realizations;
using DAL.Injections;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Injections;

public static class ServiceCollectionExtensions
{
    public static void AddBusinessDependencies(this IServiceCollection services)
    {
        services.AddDalDependencies(DbConnection.GetMySqlConnection());

        var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new BllAutoMapperProfiles()); });

        services.AddSingleton(mapperConfig.CreateMapper());

        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<ITaskService, TaskService>();
    }
}