using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HeartOfGold.Models;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace HeartOfGold.ViewModels
{
    public class ProfileViewModel
    {
        public string StudentNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public Request Request { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public List<Request> Requests { get; set; }

    }
}