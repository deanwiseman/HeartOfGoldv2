using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HeartOfGold.Models;

namespace HeartOfGold.ViewModels
{
    public class RequestListViewModel
    {
        public Request Requests { get; set; }
        public IEnumerable<RequestStatus> RequestStatus { get; set; }
    }
}