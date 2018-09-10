using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HeartOfGold.Models;

namespace HeartOfGold.ViewModels
{
    public class StudentViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}