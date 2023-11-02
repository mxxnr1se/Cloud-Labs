﻿// <auto-generated />
using System;
using DBContext.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DBContext.Migrations
{
    [DbContext(typeof(TaskTrackingSystemContext))]
    partial class TaskTrackingSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Web project 1 description",
                            Name = "Web project 1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Web project 2 description",
                            Name = "Web project 2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Web project 3 description",
                            Name = "Web project 3"
                        });
                });

            modelBuilder.Entity("Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("LastUpdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("TaskPriority")
                        .HasColumnType("int");

                    b.Property<int>("TaskStatus")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2023, 9, 5, 16, 36, 11, 158, DateTimeKind.Local).AddTicks(6350),
                            Description = "Task1 description",
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Task1",
                            ProjectId = 1,
                            TaskPriority = 2,
                            TaskStatus = 1,
                            UserId = 3
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2023, 9, 6, 16, 36, 11, 158, DateTimeKind.Local).AddTicks(6420),
                            Description = "Task2 description",
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Task2",
                            ProjectId = 1,
                            TaskPriority = 1,
                            TaskStatus = 2,
                            UserId = 3
                        },
                        new
                        {
                            Id = 3,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2023, 9, 3, 16, 36, 11, 158, DateTimeKind.Local).AddTicks(6420),
                            Description = "Task3 description",
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Task3",
                            ProjectId = 1,
                            TaskPriority = 3,
                            TaskStatus = 3,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2023, 9, 8, 16, 36, 11, 158, DateTimeKind.Local).AddTicks(6430),
                            Description = "Task4 description",
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Task4",
                            ProjectId = 1,
                            TaskPriority = 2,
                            TaskStatus = 2,
                            UserId = 3
                        },
                        new
                        {
                            Id = 5,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2023, 9, 4, 16, 36, 11, 158, DateTimeKind.Local).AddTicks(6430),
                            Description = "Task5 description",
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Task5",
                            ProjectId = 1,
                            TaskPriority = 1,
                            TaskStatus = 1,
                            UserId = 4
                        },
                        new
                        {
                            Id = 6,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2023, 9, 6, 16, 36, 11, 158, DateTimeKind.Local).AddTicks(6500),
                            Description = "Task6 description",
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Task6",
                            ProjectId = 1,
                            TaskPriority = 3,
                            TaskStatus = 3,
                            UserId = 4
                        },
                        new
                        {
                            Id = 7,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2023, 9, 5, 16, 36, 11, 158, DateTimeKind.Local).AddTicks(6500),
                            Description = "Task7 description",
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Task7",
                            ProjectId = 1,
                            TaskPriority = 2,
                            TaskStatus = 1,
                            UserId = 3
                        },
                        new
                        {
                            Id = 8,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2023, 9, 7, 16, 36, 11, 158, DateTimeKind.Local).AddTicks(6510),
                            Description = "Task8 description",
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Task8",
                            ProjectId = 1,
                            TaskPriority = 4,
                            TaskStatus = 1,
                            UserId = 4
                        },
                        new
                        {
                            Id = 9,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2023, 9, 3, 16, 36, 11, 158, DateTimeKind.Local).AddTicks(6510),
                            Description = "Task9 description",
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Task9",
                            ProjectId = 1,
                            TaskPriority = 4,
                            TaskStatus = 2,
                            UserId = 4
                        },
                        new
                        {
                            Id = 10,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2023, 9, 5, 16, 36, 11, 158, DateTimeKind.Local).AddTicks(6510),
                            Description = "Task10 description",
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Task10",
                            ProjectId = 1,
                            TaskPriority = 1,
                            TaskStatus = 4,
                            UserId = 3
                        },
                        new
                        {
                            Id = 11,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2023, 9, 8, 16, 36, 11, 158, DateTimeKind.Local).AddTicks(6520),
                            Description = "Task11 description",
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Task11",
                            ProjectId = 1,
                            TaskPriority = 2,
                            TaskStatus = 5,
                            UserId = 4
                        },
                        new
                        {
                            Id = 12,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2023, 9, 6, 16, 36, 11, 158, DateTimeKind.Local).AddTicks(6520),
                            Description = "Task12 description",
                            LastUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Task12",
                            ProjectId = 1,
                            TaskPriority = 3,
                            TaskStatus = 2,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "347cf869-ba64-4c3e-8ecf-ed3ed37f77c3",
                            Email = "admin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Adminname",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEMVVFhrMEM4V+UX09kHybmYqHMR7weo1bNW99DsZShy4C9MrKN4tp54VcdZ66Wf4MA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f0fb7b62-e1d1-4c11-a95e-4d378cd439ad",
                            Surname = "Adminsurname",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "343df79f-f01c-456e-b905-dbfe965c1e49",
                            Email = "manager@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Managername",
                            LockoutEnabled = false,
                            NormalizedEmail = "MANAGER@GMAIL.COM",
                            NormalizedUserName = "MANAGER",
                            PasswordHash = "AQAAAAIAAYagAAAAENC9on9F8RH4I71IZK+/x7gfvSG5XTQFVyUBGkfFmvxmcIA+GCLF6Ria0CCiviKSpQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6608d38c-fd88-414c-ad4f-0b1b6d9e01d5",
                            Surname = "Managersurname",
                            TwoFactorEnabled = false,
                            UserName = "manager"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ad477648-47e7-421a-a513-6291ffdbdf33",
                            Email = "user@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Username",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@GMAIL.COM",
                            NormalizedUserName = "USER",
                            PasswordHash = "AQAAAAIAAYagAAAAEGWRqtjM+laDYlkW2K4mkCuwm9EbRktcNPHeVRTj7hO2mfvZ1kO6eaWzTmaBkYdfeQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "45a47563-64c0-4852-9ce7-7b3592033f0c",
                            Surname = "Usersurname",
                            TwoFactorEnabled = false,
                            UserName = "user"
                        },
                        new
                        {
                            Id = 4,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "05a3df56-dc28-4cf9-b68a-57087d56d0ea",
                            Email = "user2@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Username2",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER2@GMAIL.COM",
                            NormalizedUserName = "USER2",
                            PasswordHash = "AQAAAAIAAYagAAAAEFgdP8ChJpNJ1VB36l0dq76v/0FJCM7cS81dFHl1uW4Hu3cZgULTMnR04hDF+wSjsw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "0a573bbe-afe3-4a5f-833d-1325782d38bd",
                            Surname = "Usersurname2",
                            TwoFactorEnabled = false,
                            UserName = "user2"
                        });
                });

            modelBuilder.Entity("Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = 3,
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 3
                        },
                        new
                        {
                            UserId = 4,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("UsersProjects", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersProjects");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            UserId = 1
                        },
                        new
                        {
                            ProjectId = 1,
                            UserId = 2
                        },
                        new
                        {
                            ProjectId = 1,
                            UserId = 3
                        },
                        new
                        {
                            ProjectId = 2,
                            UserId = 1
                        },
                        new
                        {
                            ProjectId = 2,
                            UserId = 2
                        },
                        new
                        {
                            ProjectId = 2,
                            UserId = 3
                        },
                        new
                        {
                            ProjectId = 3,
                            UserId = 1
                        },
                        new
                        {
                            ProjectId = 3,
                            UserId = 2
                        },
                        new
                        {
                            ProjectId = 3,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Entities.Task", b =>
                {
                    b.HasOne("Entities.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.User", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Entities.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Entities.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UsersProjects", b =>
                {
                    b.HasOne("Entities.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Project", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}