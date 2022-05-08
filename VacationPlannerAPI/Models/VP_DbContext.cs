﻿using Microsoft.EntityFrameworkCore;

namespace VacationPlannerAPI.Models
{
    public class VP_DbContext : DbContext
    {
        public VP_DbContext(DbContextOptions<VP_DbContext> options) : base(options)
        { }

        public DbSet<Employee> employees { get; set; }
        public DbSet<UserPassword> login { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPassword>().HasIndex(x => x.Username).IsUnique();
        }
    }
}
