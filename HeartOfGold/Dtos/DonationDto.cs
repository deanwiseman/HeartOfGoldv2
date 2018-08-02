using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using HeartOfGold.Models;

namespace HeartOfGold.Dtos
{
    public class DonationDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name of the donation.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Range(1, 999)]
        [Required]
        public int Quantity { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("Category")]
        public byte CategoryId { get; set; }

        public Donor Donor { get; set; }

        [ForeignKey("Donor")]
        public int DonorId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }


        public DonationDto()
        {
            this.IsActive = true;
            this.DateAdded = DateTime.Now;
            this.DateAdded.ToShortDateString();
        }
    }
}