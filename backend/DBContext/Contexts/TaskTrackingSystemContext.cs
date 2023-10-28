using DBContext.Configurations;
using DBContext.DbSeeds;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Task = Entities.Task;

namespace DBContext.Contexts;

public class TaskTrackingSystemContext : IdentityDbContext<User, UserRole, int>
{
    public TaskTrackingSystemContext(DbContextOptions<TaskTrackingSystemContext> options) : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.ConfigureWarnings(warnings =>
                                                 warnings.Ignore(
                                                         CoreEventId.RowLimitingOperationWithoutOrderByWarning));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new TaskConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        BasicSeed.Seed(modelBuilder);
    }
}

public class TaskTrackingSystemContextFactory : IDesignTimeDbContextFactory<TaskTrackingSystemContext>
{
    public TaskTrackingSystemContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TaskTrackingSystemContext>();
        optionsBuilder.UseMySQL(Environment.GetEnvironmentVariable("ConnectionString"));

        return new TaskTrackingSystemContext(optionsBuilder.Options);
    }
}