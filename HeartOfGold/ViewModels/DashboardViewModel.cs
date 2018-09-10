using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HeartOfGold.Models;

namespace HeartOfGold.ViewModels
{
    public class DashboardViewModel
    {
        public int OutstandingStudentRequests { get; set; }
        public Email Email { get; set; }
    }
}