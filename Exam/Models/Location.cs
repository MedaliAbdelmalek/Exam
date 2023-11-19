﻿using Exam.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class Location:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Location Logo")]
        [Required(ErrorMessage = "Location logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Location Name")]
        [Required(ErrorMessage = "Location name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Location description is required")]
        public string Description { get; set; }

        //Relationships
        public List<Event> Events { get; set; }
    }
}
