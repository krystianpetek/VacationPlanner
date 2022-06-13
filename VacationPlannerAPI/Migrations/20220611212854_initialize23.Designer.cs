﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VacationPlannerAPI.Database;

#nullable disable

namespace VacationPlannerAPI.Migrations
{
    [DbContext(typeof(VacationPlannerDbContext))]
    [Migration("20220611212854_initialize23")]
    partial class initialize23
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VacationPlannerAPI.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdministratorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId")
                        .IsUnique();

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("VacationPlannerAPI.Models.DayOffRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DayOffRequestDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfLeaveId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TypeOfLeaveId")
                        .IsUnique();

                    b.ToTable("DayOffRequests");
                });

            modelBuilder.Entity("VacationPlannerAPI.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvailableNumberOfDays")
                        .HasColumnType("int");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfDays")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserLoginId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserLoginId")
                        .IsUnique()
                        .HasFilter("[UserLoginId] IS NOT NULL");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("VacationPlannerAPI.Models.RolePerson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RolePerson");
                });

            modelBuilder.Entity("VacationPlannerAPI.Models.TypeOfLeaveRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid>("DayOffRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DayOffRequestId");

                    b.ToTable("TypeOfLeave");
                });

            modelBuilder.Entity("VacationPlannerAPI.Models.UserLogin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime?>("PasswordLastChanged")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("UsersLogin");
                });

            modelBuilder.Entity("VacationPlannerAPI.Models.Company", b =>
                {
                    b.HasOne("VacationPlannerAPI.Models.UserLogin", "Administrator")
                        .WithOne()
                        .HasForeignKey("VacationPlannerAPI.Models.Company", "AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrator");
                });

            modelBuilder.Entity("VacationPlannerAPI.Models.DayOffRequest", b =>
                {
                    b.HasOne("VacationPlannerAPI.Models.Employee", "Employee")
                        .WithMany("DayOffRequests")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VacationPlannerAPI.Models.TypeOfLeaveRequest", "TypeOfLeave")
                        .WithOne()
                        .HasForeignKey("VacationPlannerAPI.Models.DayOffRequest", "TypeOfLeaveId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("TypeOfLeave");
                });

            modelBuilder.Entity("VacationPlannerAPI.Models.Employee", b =>
                {
                    b.HasOne("VacationPlannerAPI.Models.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("VacationPlannerAPI.Models.UserLogin", "UserLogin")
                        .WithOne()
                        .HasForeignKey("VacationPlannerAPI.Models.Employee", "UserLoginId");

                    b.Navigation("Company");

                    b.Navigation("UserLogin");
                });

            modelBuilder.Entity("VacationPlannerAPI.Models.TypeOfLeaveRequest", b =>
                {
                    b.HasOne("VacationPlannerAPI.Models.DayOffRequest", "DayOffRequest")
                        .WithMany()
                        .HasForeignKey("DayOffRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DayOffRequest");
                });

            modelBuilder.Entity("VacationPlannerAPI.Models.UserLogin", b =>
                {
                    b.HasOne("VacationPlannerAPI.Models.RolePerson", "Role")
                        .WithOne("UserLogin")
                        .HasForeignKey("VacationPlannerAPI.Models.UserLogin", "RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("VacationPlannerAPI.Models.Company", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("VacationPlannerAPI.Models.Employee", b =>
                {
                    b.Navigation("DayOffRequests");
                });

            modelBuilder.Entity("VacationPlannerAPI.Models.RolePerson", b =>
                {
                    b.Navigation("UserLogin");
                });
#pragma warning restore 612, 618
        }
    }
}
