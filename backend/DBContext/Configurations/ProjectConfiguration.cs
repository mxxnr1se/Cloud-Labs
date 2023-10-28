using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DBContext.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

        builder
                .Property(p => p.Description)
                .HasMaxLength(500)
                .IsRequired();

        builder
                .HasMany(p => p.Users)
                .WithMany(u => u.Projects)
                .UsingEntity<Dictionary<string, object>>(
                        "UsersProjects",
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId"),
                        l => l.HasOne<Project>().WithMany().HasForeignKey("ProjectId"),
                        je =>
                        {
                            je.HasKey("ProjectId", "UserId");
                            je.HasData(
                                    new { ProjectId = 1, UserId = 1 },
                                    new { ProjectId = 1, UserId = 2 },
                                    new { ProjectId = 1, UserId = 3 },
                                    new { ProjectId = 2, UserId = 1 },
                                    new { ProjectId = 2, UserId = 2 },
                                    new { ProjectId = 2, UserId = 3 },
                                    new { ProjectId = 3, UserId = 1 },
                                    new { ProjectId = 3, UserId = 2 },
                                    new { ProjectId = 3, UserId = 3 }
                            );
                        });
    }
}