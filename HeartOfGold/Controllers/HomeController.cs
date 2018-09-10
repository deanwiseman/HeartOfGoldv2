using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeartOfGold.Models;
using HeartOfGold.ViewModels;
using System.Data.Entity;

namespace HeartOfGold.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = Roles.Administrator)]
        public ViewResult Dashboard()
        {
            int OutstandingRequests = _context.Requests.Where(r => r.RequestStatusId == 1).Count();

            var viewModel = new DashboardViewModel
            {
                OutstandingStudentRequests = OutstandingRequests
            };



            return View(viewModel);
        }
    }
}