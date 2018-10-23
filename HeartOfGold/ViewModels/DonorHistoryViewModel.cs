using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HeartOfGold.Models;

namespace HeartOfGold.ViewModels
{
    public class DonorHistoryViewModel
    {
        public Email Email { get; set; }

        public Donor Donor { get; set; }

        public IEnumerable<Item> Donations { get; set; }
    }
}