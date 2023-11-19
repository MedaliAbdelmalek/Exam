using Exam.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Exam.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest_Event>().HasKey(am => new
            {
                am.GuestId,
                am.EventId
            });

            modelBuilder.Entity<Guest_Event>().HasOne(m => m.Event).WithMany(am => am.Guests_Events).HasForeignKey(m => m.EventId);
            modelBuilder.Entity<Guest_Event>().HasOne(m => m.Guest).WithMany(am => am.Guests_Events).HasForeignKey(m => m.GuestId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Guest_Event> Guests_Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Organizer> Organizers { get; set; }


        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
