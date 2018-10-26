using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeartOfGold.Models
{
    // Item objects are the donated things, or 'items' that are recorded on the system.
    public class Item
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name of the donation.")]
        [Display(Name = "Name of Donation")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Range(0, 999)]
        [Required]
        public int Quantity { get; set; }

        public bool IsActive { get; set; }

        public Category Category { get; set; }

        [ForeignKey("Category")]
        [Display(Name = "Type of Donation")]
        public byte CategoryId { get; set; }

        public Donor Donor { get; set; }

        [ForeignKey("Donor")]
        [Display(Name = "Donated By")]
        public int DonorId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [NotMapped]
        public bool MustDelete { get; set; }

        public Item()
        {
            this.IsActive = true;
            this.DateAdded = DateTime.Now;
            this.DateAdded.ToShortDateString();
        }
    }
}