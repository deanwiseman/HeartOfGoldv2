using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HeartOfGold.Models;

namespace HeartOfGold.ViewModels
{
    public class ChartViewModel
    {
        public int Quantity { get; set; }
        public string Month { get; set; }

        string[] months = new string[] {"January", "February", "March", "April", "May",
                                        "June", "July", "August", "September", "October", "November", "December"};
    }
}