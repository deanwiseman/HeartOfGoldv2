using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HeartOfGold.Models
{
    // Donors to Heart Of Gold
    public class Donor
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Surname")]
        [Required]
        public string LastName { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}