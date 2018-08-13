using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HeartOfGold.Models;

namespace HeartOfGold.ViewModels
{
    public class DonorViewModel
    {
        public Donor Donor { get; set; }

        public IEnumerable<Donor> Donors { get; set; }
    }
}