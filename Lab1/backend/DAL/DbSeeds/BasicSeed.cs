using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.Enums;
using Task = DAL.Entities.Task;
using TaskStatus = Shared.Enums.TaskStatus;

namespace DAL.DbSeeds;

public static class BasicSeed
{
  public static void Seed(ModelBuilder modelBuilder)
  {
    #region Identity

    modelBuilder.Entity<UserRole>().HasData(
            new UserRole { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
            new UserRole { Id = 2, Name = "Manager", NormalizedName = "MANAGER" },
            new UserRole { Id = 3, Name = "User", NormalizedName = "USER" }
    );

    var passwordHasher = new PasswordHasher<User>();
    var users = new List<User>
        {
                new()
                {
                        Id = 1,
                        UserName = "admin",
                        NormalizedUserName = "admin".ToUpper(),
                        FirstName = "Adminname",
                        Surname = "Adminsurname",
                        Email = "admin@gmail.com",
                        NormalizedEmail = "admin@gmail.com".ToUpper(),
                        EmailConfirmed = true,
                        PasswordHash = passwordHasher.HashPassword(null, "123Qwerty"),
                        SecurityStamp = Guid.NewGuid().ToString()
                },

                new()
                {
                        Id = 2,
                        UserName = "manager",
                        NormalizedUserName = "manager".ToUpper(),
                        FirstName = "Managername",
                        Surname = "Managersurname",
                        Email = "manager@gmail.com",
                        NormalizedEmail = "manager@gmail.com".ToUpper(),
                        EmailConfirmed = true,
                        PasswordHash = passwordHasher.HashPassword(null, "123Qwerty"),
                        SecurityStamp = Guid.NewGuid().ToString()
                },

                new()
                {
                        Id = 3,
                        UserName = "user",
                        NormalizedUserName = "user".ToUpper(),
                        FirstName = "Username",
                        Surname = "Usersurname",
                        Email = "user@gmail.com",
                        NormalizedEmail = "user@gmail.com".ToUpper(),
                        EmailConfirmed = true,
                        PasswordHash = passwordHasher.HashPassword(null, "123Qwerty"),
                        SecurityStamp = Guid.NewGuid().ToString()
                },

                new()
                {
                        Id = 4,
                        UserName = "user2",
                        NormalizedUserName = "user2".ToUpper(),
                        FirstName = "Username2",
                        Surname = "Usersurname2",
                        Email = "user2@gmail.com",
                        NormalizedEmail = "user2@gmail.com".ToUpper(),
                        EmailConfirmed = true,
                        PasswordHash = passwordHasher.HashPassword(null, "123Qwerty"),
                        SecurityStamp = Guid.NewGuid().ToString()
                }
        };
    modelBuilder.Entity<User>().HasData(users);

    modelBuilder.Entity<IdentityUserRole<int>>().HasData(
            new IdentityUserRole<int> { UserId = 1, RoleId = 1 },
            new IdentityUserRole<int> { UserId = 2, RoleId = 2 },
            new IdentityUserRole<int> { UserId = 3, RoleId = 3 },
            new IdentityUserRole<int> { UserId = 4, RoleId = 3 }
    );

    #endregion

    modelBuilder.Entity<Project>().HasData(
            new Project { Id = 1, Name = "Web project 1", Description = "Web project 1 description" },
            new Project { Id = 2, Name = "Web project 2", Description = "Web project 2 description" },
            new Project { Id = 3, Name = "Web project 3", Description = "Web project 3 description" }
    );

    modelBuilder.Entity<Task>().HasData(
            new Task
            {
              Id = 1,
              Name = "Task1",
              Description = "Task1 description",
              Deadline = DateTime.Now.AddDays(3),
              TaskStatus = TaskStatus.Open,
              TaskPriority = TaskPriority.Medium,
              ProjectId = 1,
              UserId = 3
            },
            new Task
            {
              Id = 2,
              Name = "Task2",
              Description = "Task2 description",
              Deadline = DateTime.Now.AddDays(4),
              TaskStatus = TaskStatus.InProgress,
              TaskPriority = TaskPriority.Low,
              ProjectId = 1,
              UserId = 3
            },
            new Task
            {
              Id = 3,
              Name = "Task3",
              Description = "Task3 description",
              Deadline = DateTime.Now.AddDays(1),
              TaskStatus = TaskStatus.Completed,
              TaskPriority = TaskPriority.High,
              ProjectId = 1,
              UserId = 3
            },
            new Task
            {
              Id = 4,
              Name = "Task4",
              Description = "Task4 description",
              Deadline = DateTime.Now.AddDays(6),
              TaskStatus = TaskStatus.InProgress,
              TaskPriority = TaskPriority.Medium,
              ProjectId = 1,
              UserId = 3
            },
            new Task
            {
              Id = 5,
              Name = "Task5",
              Description = "Task5 description",
              Deadline = DateTime.Now.AddDays(2),
              TaskStatus = TaskStatus.Open,
              TaskPriority = TaskPriority.Low,
              ProjectId = 1,
              UserId = 4
            },
            new Task
            {
              Id = 6,
              Name = "Task6",
              Description = "Task6 description",
              Deadline = DateTime.Now.AddDays(4),
              TaskStatus = TaskStatus.Completed,
              TaskPriority = TaskPriority.High,
              ProjectId = 1,
              UserId = 4
            },
            new Task
            {
              Id = 7,
              Name = "Task7",
              Description = "Task7 description",
              Deadline = DateTime.Now.AddDays(3),
              TaskStatus = TaskStatus.Open,
              TaskPriority = TaskPriority.Medium,
              ProjectId = 1,
              UserId = 3
            },
            new Task
            {
              Id = 8,
              Name = "Task8",
              Description = "Task8 description",
              Deadline = DateTime.Now.AddDays(5),
              TaskStatus = TaskStatus.Open,
              TaskPriority = TaskPriority.Critical,
              ProjectId = 1,
              UserId = 4
            },
            new Task
            {
              Id = 9,
              Name = "Task9",
              Description = "Task9 description",
              Deadline = DateTime.Now.AddDays(1),
              TaskStatus = TaskStatus.InProgress,
              TaskPriority = TaskPriority.Critical,
              ProjectId = 1,
              UserId = 4
            },
            new Task
            {
              Id = 10,
              Name = "Task10",
              Description = "Task10 description",
              Deadline = DateTime.Now.AddDays(3),
              TaskStatus = TaskStatus.OnHold,
              TaskPriority = TaskPriority.Low,
              ProjectId = 1,
              UserId = 3
            },
            new Task
            {
              Id = 11,
              Name = "Task11",
              Description = "Task11 description",
              Deadline = DateTime.Now.AddDays(6),
              TaskStatus = TaskStatus.Cancelled,
              TaskPriority = TaskPriority.Medium,
              ProjectId = 1,
              UserId = 4
            },
            new Task
            {
              Id = 12,
              Name = "Task12",
              Description = "Task12 description",
              Deadline = DateTime.Now.AddDays(4),
              TaskStatus = TaskStatus.InProgress,
              TaskPriority = TaskPriority.High,
              ProjectId = 1,
              UserId = 3
            }
    );
  }
}