using Exam.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public EventCategory EventCategory { get; set; }

        public List<Guest_Event> Guests_Events {  get; set; }

        //location
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        //Organizer
        public int OrganizerId { get; set; }
        [ForeignKey("OrganizerId")]
        public Organizer Organizer { get; set; }

    }
}
