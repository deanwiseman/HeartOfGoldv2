using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HeartOfGold.Models;

namespace HeartOfGold.ViewModels
{
    public class RequestFormViewModel
    {
        public Request Request { get; set; }

        public IEnumerable<Category> RequestCategories { get; set; }
    }
}