using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Location Logo")]
        public string Logo { get; set; }

        [Display(Name = "Location Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
        public List<Event> Events { get; set; }
    }
}
