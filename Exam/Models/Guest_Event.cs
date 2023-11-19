namespace Exam.Models
{
    public class Guest_Event
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int GuestId { get; set; }
        public Guest Guest { get; set; }
    }
}
