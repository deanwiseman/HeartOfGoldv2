using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeartOfGold.Models;

namespace HeartOfGold.ViewModels
{
    public class NewItemViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public int SelectedCategory { get; set; }
        public IEnumerable<SelectListItem> SelectCategoryList { get; set;
        }
        public Item Item { get; set; }

        public IEnumerable<Donor> Donors { get; set; }
        public int SelectedDonor { get; set; }
        public IEnumerable<SelectListItem> SelectDonorList { get; set; }
    }
}