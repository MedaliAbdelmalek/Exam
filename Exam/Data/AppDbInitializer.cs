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
                            Logo = "http://dotnethow.net/images/locations/location-1.jpeg",
                            Description = "This is the description of the first place"
                        },
                        new Location()
                        {
                            Name = "Location 2",
                            Logo = "http://dotnethow.net/images/locations/location-2.jpeg",
                            Description = "This is the description of the second place"
                        },
                        new Location()
                        {
                            Name = "Location 3",
                            Logo = "http://dotnethow.net/images/locations/location-3.jpeg",
                            Description = "This is the description of the third place"
                        },
                        new Location()
                        {
                            Name = "Location 4",
                            Logo = "http://dotnethow.net/images/locations/location-4.jpeg",
                            Description = "This is the description of the fourth place"
                        },
                        new Location()
                        {
                            Name = "Location 5",
                            Logo = "http://dotnethow.net/images/locations/location-5.jpeg",
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
                            ProfilePictureURL = "http://dotnethow.net/images/guests/guest-1.jpeg"

                        },
                        new Guest()
                        {
                            FullName = "Guest 2",
                            Bio = "This is the Bio of the second guest",
                            ProfilePictureURL = "http://dotnethow.net/images/guests/guest-2.jpeg"
                        },
                        new Guest()
                        {
                            FullName = "Guest 3",
                            Bio = "This is the Bio of the second guest",
                            ProfilePictureURL = "http://dotnethow.net/images/guests/guest-3.jpeg"
                        },
                        new Guest()
                        {
                            FullName = "Guest 4",
                            Bio = "This is the Bio of the second guest",
                            ProfilePictureURL = "http://dotnethow.net/images/guests/guest-4.jpeg"
                        },
                        new Guest()
                        {
                            FullName = "Guest 5",
                            Bio = "This is the Bio of the second guest",
                            ProfilePictureURL = "http://dotnethow.net/images/guests/guest-5.jpeg"
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
                            ProfilePictureURL = "http://dotnethow.net/images/organizers/organizer-1.jpeg"

                        },
                        new Organizer()
                        {
                            FullName = "Organizer 2",
                            Bio = "This is the Bio of the second organizer",
                            ProfilePictureURL = "http://dotnethow.net/images/organizers/organizer-2.jpeg"
                        },
                        new Organizer()
                        {
                            FullName = "Organizer 3",
                            Bio = "This is the Bio of the second organizer",
                            ProfilePictureURL = "http://dotnethow.net/images/organizers/organizer-3.jpeg"
                        },
                        new Organizer()
                        {
                            FullName = "Organizer 4",
                            Bio = "This is the Bio of the second organizer",
                            ProfilePictureURL = "http://dotnethow.net/images/organizers/organizer-4.jpeg"
                        },
                        new Organizer()
                        {
                            FullName = "Organizer 5",
                            Bio = "This is the Bio of the second organizer",
                            ProfilePictureURL = "http://dotnethow.net/images/organizers/organizer-5.jpeg"
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
                            Description = "This is the Innovation Conference event description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/events/event-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            LocationId = 3,
                            OrganizerId = 3,
                            EventCategory = EventCategory.Conference
                        },
                        new Event()
                        {
                            Name = "City Lights Celebrationn",
                            Description = "This is the City Lights Celebration event description",
                            Price = 29.50,
                            ImageURL = "http://dotnethow.net/images/events/event-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            LocationId = 1,
                            OrganizerId = 1,
                            EventCategory = EventCategory.Party
                        },
                        new Event()
                        {
                            Name = "Business Strategy Masterclass",
                            Description = "This is the Business Strategy Masterclass event description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/events/event-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            LocationId = 4,
                            OrganizerId = 4,
                            EventCategory = EventCategory.Seminar
                        },
                        new Event()
                        {
                            Name = "Web Development Bootcamp",
                            Description = "This isWeb Development Bootcamp event description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/events/event-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            LocationId = 1,
                            OrganizerId = 2,
                            EventCategory = EventCategory.Workshop
                        },
                        new Event()
                        {
                            Name = "Leadership Development Workshop",
                            Description = "This is the Leadership Development Workshop event description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/events/event-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            LocationId = 1,
                            OrganizerId = 3,
                            EventCategory = EventCategory.Workshop
                        },
                        new Event()
                        {
                            Name = "Future of AI",
                            Description = "This is the Future of AI event description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/events/event-8.jpeg",
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
                string adminUserEmail = "admin@etickets.com";

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


                string appUserEmail = "user@etickets.com";

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
