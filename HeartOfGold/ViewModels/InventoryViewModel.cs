using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HeartOfGold.Models;

namespace HeartOfGold.ViewModels
{
    public class InventoryViewModel
    {
        public Item Item { get; set; }

        public IEnumerable<Item> Donations { get; set; }

        [Display(Name = "Display deleted donation entries")]
        public bool ShowDeletedDonations { get; set; }
    }
}