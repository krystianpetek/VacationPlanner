using Microsoft.EntityFrameworkCore;
using VacationPlannerAPI.RestModels;

namespace VacationPlannerAPI.Models
{
    public class VacationPlannerDbContext : DbContext
    {
        public VacationPlannerDbContext(DbContextOptions<VacationPlannerDbContext> options) : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserLogin> UsersLogin { get; set; }
        public DbSet<DayOffRequest> DayOffRequests { get; set; }

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

        }
    }
}
