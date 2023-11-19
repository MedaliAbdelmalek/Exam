using Exam.Data.Base;
using Exam.Data.ViewModels;
using Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam.Data.Services
{
    public class EventsService : EntityBaseRepository<Event>, IEventsService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public EventsService(AppDbContext context, IWebHostEnvironment hostingEnvironment) : base(context)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;

        }

        public async Task AddNewEventAsync(NewEventVM data, IFormFile file)
        {
            var newEvent = new Event()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = file.FileName,
                LocationId = data.LocationId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                EventCategory = data.EventCategory,
                OrganizerId = data.OrganizerId
            };

            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();
            saveFile(file, newEvent.Name);

            //Add Event Guests
            foreach (var guestId in data.GuestIds)
            {
                var newGuestEvent = new Guest_Event()
                {
                    EventId = newEvent.Id,
                    GuestId = guestId
                };
                await _context.Guests_Events.AddAsync(newGuestEvent);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            var eventDetails = await _context.Events
                .Include(l => l.Location)
                .Include(o => o.Organizer)
                .Include(ge => ge.Guests_Events).ThenInclude(g => g.Guest)
                .FirstOrDefaultAsync(n => n.Id == id);

            return eventDetails;
        }

        public async Task<NewEventDropdownsVM> GetNewEventDropdownsValues()
        {
            var response = new NewEventDropdownsVM()
            {
                Guests = await _context.Guests.OrderBy(n => n.FullName).ToListAsync(),
                Locations = await _context.Locations.OrderBy(n => n.Name).ToListAsync(),
                Organizers = await _context.Organizers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateEventAsync(NewEventVM data)
        {
            var dbEvent = await _context.Events.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbEvent != null)
            {
                dbEvent.Name = data.Name;
                dbEvent.Description = data.Description;
                dbEvent.Price = data.Price;
                dbEvent.ImageURL = data.ImageURL;
                dbEvent.LocationId = data.LocationId;
                dbEvent.StartDate = data.StartDate;
                dbEvent.EndDate = data.EndDate;
                dbEvent.EventCategory = data.EventCategory;
                dbEvent.OrganizerId = data.OrganizerId;
                await _context.SaveChangesAsync();
            }

            //Remove existing guests
            var existingGuestsDb = _context.Guests_Events.Where(n => n.EventId == data.Id).ToList();
            _context.Guests_Events.RemoveRange(existingGuestsDb);
            await _context.SaveChangesAsync();

            //Add Event Guests
            foreach (var guestId in data.GuestIds)
            {
                var newGuestEvent = new Guest_Event()
                {
                    EventId = data.Id,
                    GuestId = guestId
                };
                await _context.Guests_Events.AddAsync(newGuestEvent);
            }
            await _context.SaveChangesAsync();
        }
    
    
        private void saveFile(IFormFile file,String eventTitle)
        {
            var fileName = eventTitle+"_"+Path.GetFileName(file.FileName);

            // Specify the directory where you want to move the file
            var uploadDir = Path.Combine(_hostingEnvironment.WebRootPath, "EventUploads");

            // Combine the directory and file name to get the full path
            var filePath = Path.Combine(uploadDir, fileName);

            // Create the directory if it doesn't exist
            if (!Directory.Exists(uploadDir))
            {
                Directory.CreateDirectory(uploadDir);
            }

            // Move the file to the specified directory
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }
    
    }
}
