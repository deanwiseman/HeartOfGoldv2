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

        [StringLength(9, MinimumLength = 9, ErrorMessage = "Enter a valid student number")]
        [Required]
        public string StudentNumber { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public RequestStatus RequestStatus { get; set; }

        [ForeignKey("RequestStatus")]
        [Display(Name = "Status")]
        public byte RequestStatusId { get; set; }

        // Constructor initialises the status of a request to 'pending' (id = 1)
        public Request()
        {
            this.RequestStatusId = 1;
        }
    }
}