using BugTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

// database SQL
namespace BugTrackerAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        // public DbSet<TicketWorkedOn> TicketsWorkedOn { get; set; }


        // protected override void onModelCreating(ModelBuilder builder) 
        // {
        //     builder.Entity<TicketWorkedOn>()
        //         .HasKey(key => new { key.EmployeeWorkerId, key.TicketId });

        //     builder.Entity<TicketWorkedOn>()
        //         .HasOne(u => u.TicketEmployeeWorked)
        //         .WithMany(u => u.EmployeeWorker)
        //         .HasForeignKey(u => u)
        // }
    }
}