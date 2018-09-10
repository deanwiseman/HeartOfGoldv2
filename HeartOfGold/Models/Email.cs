using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HeartOfGold.Models
{
    [NotMapped]
    public class Email
    {
        [Display(Name = "To" )]
        [Required]
        public string ToEmail { get; set; }

        [Required]
        public string Subject { get; set; }
        
        [Required]
        public string Body { get; set; }

    }
}