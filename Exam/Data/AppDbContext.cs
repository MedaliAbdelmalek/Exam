using Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest_Event>().HasKey(ge => new
            {
                ge.GuestId,
                ge.EventId
            });
            modelBuilder.Entity<Guest_Event>().HasOne(e => e.Event).WithMany(ge =>ge.Guests_Events).HasForeignKey(e =>e.EventId);
            modelBuilder.Entity<Guest_Event>().HasOne(e => e.Guest).WithMany(ge => ge.Guests_Events).HasForeignKey(e => e.GuestId);
        }
        
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Guest_Event> Guests_Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Organizer> Organizers { get; set; }


    }
}
