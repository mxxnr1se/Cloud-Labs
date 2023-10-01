using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
                .Property(u => u.FirstName)
                .HasMaxLength(50)
                .IsRequired();

        builder
                .Property(u => u.Surname)
                .HasMaxLength(50)
                .IsRequired();
    }
}