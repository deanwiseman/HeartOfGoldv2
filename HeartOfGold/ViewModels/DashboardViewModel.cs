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
        public int NumberOfStudents { get; set; }
        public int TotalFoodItems { get; set; }
        public int TotalStationeryItems { get; set; }
        public int TotalTextbookItems { get; set; }
        public int TotalOtherItems { get; set; }
        public int TotalClothesItems { get; set; }
    }
}