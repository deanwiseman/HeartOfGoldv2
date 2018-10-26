using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeartOfGold.Models
{
    public class Event
    {
        public int EventID { get; set; }

        [Required]
        [StringLength(50)]
        public string Subject { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        public string ThemeColour { get; set; }

        // This property represents a stored key for the related request.
        public int? RequestKey { get; set; }

        public Event()
        {
            if (End == null)
            {
                this.End = Start.AddMinutes(5);
            }
        }
    }
}