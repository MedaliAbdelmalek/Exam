using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class Organizer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        public string Bio { get; set; }
        public List<Event> Events { get; set; }
    }
}
