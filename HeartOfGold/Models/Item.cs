using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HeartOfGold.Models
{
    // Item objects are the donated things, or 'items' that are recorded on the system.
    public class Item
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; }
        public bool IsActive { get; set; }

        public Category Category { get; set; }

        public Donor Donor { get; set; }
    }
}