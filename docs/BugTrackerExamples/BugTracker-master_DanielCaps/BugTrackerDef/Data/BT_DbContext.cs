using BugTrackerDef.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackerDef.Data
{
    public class BT_DbContext : IdentityDbContext<ApplicationUser>
    {
        public BT_DbContext(DbContextOptions<BT_DbContext> options) : base(options){}

        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<EmployeeProjects> EmployeeProjects { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeProjects>()
            .HasKey(pr => new { pr.ProjectId, pr.EmployeeId });
            modelBuilder.Entity<EmployeeProjects>()
                .HasOne(pr => pr.Project)
                .WithMany(p => p.EmployeeProjects)
                .HasForeignKey(bc => bc.ProjectId);
            modelBuilder.Entity<EmployeeProjects>()
                .HasOne(bc => bc.Employee)
                .WithMany(c => c.EmployeeProjects)
                .HasForeignKey(bc => bc.EmployeeId);
        }

    }
}
