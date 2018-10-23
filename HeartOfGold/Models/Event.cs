using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

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

        // These two properties are purely used for implementing repeat events within the fullcalendar.io library. See more: https://fullcalendar.io/docs/eventConstraint
        public int? StartDayOfWeek { get; set; }
        public int? EndDayOfWeek { get; set; }

        public Event()
        {
            if (End == null)
            {
                this.End = Start.AddMinutes(5);
            }
        }
    }
}