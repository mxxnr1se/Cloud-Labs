using DAL.Interfaces;
using DAL.Repositories.Interfaces;
using DAL.Repositories.Realizations;
using DAL.UoWs;
using DBContext.Contexts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Injections;

public static class ServiceCollectionExtensions
{
    public static void AddDalDependencies(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<TaskTrackingSystemContext>(options =>
                                                                 options.UseMySQL(connectionString,
                                                                     o => o.UseQuerySplittingBehavior(
                                                                             QuerySplittingBehavior.SplitQuery)));

        services.AddIdentity<User, UserRole>(options => options.User.RequireUniqueEmail = true)
                .AddEntityFrameworkStores<TaskTrackingSystemContext>();

        services.AddScoped<DbContext, TaskTrackingSystemContext>();
        services.AddScoped<IUoW, EfUoW>();

        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
    }
}