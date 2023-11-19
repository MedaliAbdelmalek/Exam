using Exam.Data.Enums;
using Exam.Data.Static;
using Exam.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Exam.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //create a reference to AppDbContext
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Location
                if (!context.Locations.Any())
                {
                    context.Locations.AddRange(new List<Location>()
                    {
                        new Location()
                        {
                            Name = "Location 1",
                            Logo = "location1.jpg",
                            Description = "This is the description of the first place"
                        },
                        new Location()
                        {
                            Name = "Location 2",
                            Logo = "location2.jpg",
                            Description = "This is the description of the second place"
                        },
                        new Location()
                        {
                            Name = "Location 3",
                            Logo = "location3.jpeg",
                            Description = "This is the description of the third place"
                        },
                        new Location()
                        {
                            Name = "Location 4",
                            Logo = "location5.png",
                            Description = "This is the description of the fourth place"
                        },
                        new Location()
                        {
                            Name = "Location 5",
                            Logo = "location6.jpg",
                            Description = "This is the description of the fifth place"
                        },
                    });
                    context.SaveChanges();
                }

                //Guests
                if (!context.Guests.Any())
                {
                    context.Guests.AddRange(new List<Guest>()
                    {
                        new Guest()
                        {
                            FullName = "Guest 1",
                            Bio = "This is the Bio of the first guest",
                            ProfilePictureURL = "guest1.jpg"

                        },
                        new Guest()
                        {
                            FullName = "Guest 2",
                            Bio = "This is the Bio of the second guest",
                            ProfilePictureURL = "guest2.jpg"
                        },
                        new Guest()
                        {
                            FullName = "Guest 3",
                            Bio = "This is the Bio of the second guest",
                            ProfilePictureURL = "guest3.jpeg"
                        },
                        new Guest()
                        {
                            FullName = "Guest 4",
                            Bio = "This is the Bio of the second guest",
                            ProfilePictureURL = "guest4.jpg"
                        },
                        new Guest()
                        {
                            FullName = "Guest 5",
                            Bio = "This is the Bio of the second guest",
                            ProfilePictureURL = "guest5.jpg"
                        }
                    });
                    context.SaveChanges();
                }

                //Organizers
                if (!context.Organizers.Any())
                {
                    context.Organizers.AddRange(new List<Organizer>()
                    {
                        new Organizer()
                        {
                            FullName = "Organizer 1",
                            Bio = "This is the Bio of the first organizer",
                            ProfilePictureURL = "guest1.jpg"

                        },
                        new Organizer()
                        {
                            FullName = "Organizer 2",
                            Bio = "This is the Bio of the second organizer",
                            ProfilePictureURL = "guest2.jpg"
                        },
                        new Organizer()
                        {
                            FullName = "Organizer 3",
                            Bio = "This is the Bio of the second organizer",
                            ProfilePictureURL = "guest3.jpeg"
                        },
                        new Organizer()
                        {
                            FullName = "Organizer 4",
                            Bio = "This is the Bio of the second organizer",
                            ProfilePictureURL = "guest4.jpg"
                        },
                        new Organizer()
                        {
                            FullName = "Organizer 5",
                            Bio = "This is the Bio of the second organizer",
                            ProfilePictureURL = "guest5.jpg"
                        }
                    });
                    context.SaveChanges();
                }

                //Events
                if (!context.Events.Any())
                {
                    context.Events.AddRange(new List<Event>()
                    {
                        new Event()
                        {
                            Name = "Innovation Conference",
                            Description = "This is the  event description",
                            Price = 39.50,
                            ImageURL = "event1.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            LocationId = 3,
                            OrganizerId = 3,
                            EventCategory = EventCategory.Conference
                        },
                        new Event()
                        {
                            Name = "City Lights Celebrationn",
                            Description = "This is the  event description",
                            Price = 29.50,
                            ImageURL = "event2.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            LocationId = 1,
                            OrganizerId = 1,
                            EventCategory = EventCategory.Party
                        },
                        new Event()
                        {
                            Name = "Business Strategy Masterclass",
                            Description = "This is the  event description",
                            Price = 39.50,
                            ImageURL = "event3.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            LocationId = 4,
                            OrganizerId = 4,
                            EventCategory = EventCategory.Seminar
                        },
                        new Event()
                        {
                            Name = "Web Development Bootcamp",
                            Description = "This is the  event description",
                            Price = 39.50,
                            ImageURL = "event4.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            LocationId = 1,
                            OrganizerId = 2,
                            EventCategory = EventCategory.Workshop
                        },
                        new Event()
                        {
                            Name = "Leadership Development Workshop",
                            Description = "This is the  event description",
                            Price = 39.50,
                            ImageURL = "event5.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            LocationId = 1,
                            OrganizerId = 3,
                            EventCategory = EventCategory.Workshop
                        },
                        new Event()
                        {
                            Name = "Future of AI",
                            Description = "This is the  event description",
                            Price = 39.50,
                            ImageURL = "event5.jpg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            LocationId = 1,
                            OrganizerId = 5,
                            EventCategory = EventCategory.Conference
                        }
                    });
                    context.SaveChanges();
                }

                //Guests & Events
                if (!context.Guests_Events.Any())
                {
                    context.Guests_Events.AddRange(new List<Guest_Event>()
                    {
                        new Guest_Event()
                        {
                            GuestId = 1,
                            EventId = 1
                        },
                        new Guest_Event()
                        {
                            GuestId = 3,
                            EventId = 1
                        },

                         new Guest_Event()
                        {
                            GuestId = 1,
                            EventId = 2
                        },
                         new Guest_Event()
                        {
                            GuestId = 4,
                            EventId = 2
                        },

                        new Guest_Event()
                        {
                            GuestId = 1,
                            EventId = 3
                        },
                        new Guest_Event()
                        {
                            GuestId = 2,
                            EventId = 3
                        },
                        new Guest_Event()
                        {
                            GuestId = 5,
                            EventId = 3
                        },


                        new Guest_Event()
                        {
                            GuestId = 2,
                            EventId = 4
                        },
                        new Guest_Event()
                        {
                            GuestId = 3,
                            EventId = 4
                        },
                        new Guest_Event()
                        {
                            GuestId = 4,
                            EventId = 4
                        },


                        new Guest_Event()
                        {
                            GuestId = 2,
                            EventId = 5
                        },
                        new Guest_Event()
                        {
                            GuestId = 3,
                            EventId = 5
                        },
                        new Guest_Event()
                        {
                            GuestId = 4,
                            EventId = 5
                        },
                        new Guest_Event()
                        {
                            GuestId = 5,
                            EventId = 5
                        },


                        new Guest_Event()
                        {
                            GuestId = 3,
                            EventId = 6
                        },
                        new Guest_Event()
                        {
                            GuestId = 4,
                            EventId = 6
                        },
                        new Guest_Event()
                        {
                            GuestId = 5,
                            EventId = 6
                        },
                    });
                    context.SaveChanges();
                }


            }

        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@dali.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@exam.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }

}
