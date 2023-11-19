using Exam.Models;

namespace Exam.Data.ViewModels
{
    public class NewEventDropdownsVM
    {
        public NewEventDropdownsVM()
        {
            Organizers = new List<Organizer>();
            Locations = new List<Location>();
            Guests = new List<Guest>();
        }

        public List<Organizer> Organizers { get; set; }
        public List<Location> Locations { get; set; }
        public List<Guest> Guests { get; set; }
    }
}
