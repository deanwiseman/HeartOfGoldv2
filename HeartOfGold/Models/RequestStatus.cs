using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeartOfGold.Models
{
    public class RequestStatus
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }
      
    }
}