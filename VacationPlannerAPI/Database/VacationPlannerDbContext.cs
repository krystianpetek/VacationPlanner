using Microsoft.EntityFrameworkCore;
using VacationPlannerAPI.Models;

namespace VacationPlannerAPI.Database;

public class VacationPlannerDbContext : DbContext
{
    public VacationPlannerDbContext(DbContextOptions<VacationPlannerDbContext> options) : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<UserLogin> UsersLogin { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<DayOffRequest> DayOffRequests { get; set; }
    public DbSet<TypeOfLeaveRequest> TypeOfLeave { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserLogin>().Property(x => x.Username).IsRequired();
        modelBuilder.Entity<UserLogin>().HasIndex(x => x.Username).IsUnique();
        modelBuilder.Entity<UserLogin>().HasKey(x => x.Id);
        modelBuilder.Entity<UserLogin>().Property(x => x.Id).IsRequired();

        modelBuilder.Entity<Employee>().HasKey(x => x.Id);
        modelBuilder.Entity<Employee>().Property(x => x.Id).IsRequired();

        modelBuilder.Entity<DayOffRequest>().HasKey(x => x.Id);
        modelBuilder.Entity<DayOffRequest>().Property(x => x.Id).IsRequired();

        modelBuilder.Entity<Company>().HasKey(x => x.Id);
        modelBuilder.Entity<Company>().Property(x => x.Id).IsRequired();

        modelBuilder.Entity<Company>().HasOne(x => x.Administrator).WithOne();
        modelBuilder.Entity<Employee>().HasOne(x => x.UserLogin).WithOne();

        modelBuilder.Entity<Employee>().HasOne(x => x.Company).WithMany(q => q.Employees)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Employee>().HasMany(x => x.DayOffRequests).WithOne(q => q.Employee);
        modelBuilder.Entity<UserLogin>().HasOne(x => x.Role).WithOne(q => q.UserLogin);

        //modelBuilder.Entity<DayOffRequest>().HasOne(x => x.TypeOfLeave).WithOne().OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<TypeOfLeaveRequest>().HasData(
            new TypeOfLeaveRequest() { Id = 1, TypeOfLeave = "Annual leave" },
            new TypeOfLeaveRequest() { Id = 2, TypeOfLeave = "Leave on demand" },
            new TypeOfLeaveRequest() { Id = 3, TypeOfLeave = "Ocassional leave" },
            new TypeOfLeaveRequest() { Id = 4, TypeOfLeave = "Unpaid leave" },
            new TypeOfLeaveRequest() { Id = 5, TypeOfLeave = "Parental leave" },
            new TypeOfLeaveRequest() { Id = 6, TypeOfLeave = "Sick leave" },
            new TypeOfLeaveRequest() { Id = 7, TypeOfLeave = "Time off in lieu for overtime" });

    }
}