using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HeartOfGold.Models
{
    // A submitted request from a student.
    public class Request
    {
        public int Id { get; set; }

        [Display(Name = "NMU Student Number")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Enter a valid student number")]
        [Required(ErrorMessage = "Please enter your student number")]
        public string StudentNumber { get; set; }

        [Display(Name = "What are you in need of?")]
        [Required(ErrorMessage = "Please describe what you're looking for")]
        public string Description { get; set; }

        [Display(Name = "Date Today")]
        public DateTime Date { get; set; }

        public RequestStatus RequestStatus { get; set; }

        [ForeignKey("RequestStatus")]
        [Display(Name = "Status")]
        public byte RequestStatusId { get; set; }

        public Category Category { get; set; }

        [ForeignKey("Category")]
        [Display(Name = "Type of Donation")]
        public byte? CategoryId { get; set; }

        [NotMapped]
        public byte SelectedStatusId { get; set; }

        // Constructor initialises the status of a request to 'Open' (id = 1)
        public Request()
        {
            this.RequestStatusId = 1;
            this.Date = DateTime.Now;
            this.Date.ToShortDateString();
        }
    }
}