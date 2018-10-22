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
        [Required(ErrorMessage = "Please enter destination address.")]
        public string ToEmail { get; set; }

        [Required(ErrorMessage = "The email subject is required.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please create a body for the email.")]
        public string Body { get; set; }

    }
}