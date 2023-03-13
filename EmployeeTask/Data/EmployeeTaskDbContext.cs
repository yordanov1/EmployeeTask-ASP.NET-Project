namespace EmployeeTask.Data
{
    using EmployeeTask.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EmployeeTaskDbContext : IdentityDbContext
    {
        public EmployeeTaskDbContext(DbContextOptions<EmployeeTaskDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Task>()
                .HasOne(x => x.Employee)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);

        }       
    }
}
