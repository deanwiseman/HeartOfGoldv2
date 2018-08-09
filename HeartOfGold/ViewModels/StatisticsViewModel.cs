using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HeartOfGold.Models;

namespace HeartOfGold.ViewModels
{
    public class StatisticsViewModel
    {
        public int TotalRequests { get; set; }
        public int TotalRequestsThisYear { get; set; }
        public int TotalPendingRequests { get; set; }
        public int TotalSuccessfulRequests { get; set; }
        public int TotalUnsuccessfulReqests { get; set; }
        public int TotalAnonymousDonations { get; set; }
        public int TotalRegisteredStudents { get; set; }

    }
}