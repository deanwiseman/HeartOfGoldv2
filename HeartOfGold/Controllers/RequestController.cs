using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeartOfGold.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using HeartOfGold.ViewModels;
using PagedList;

namespace HeartOfGold.Controllers
{
    public class RequestController : Controller
    {
        private ApplicationDbContext _context;

        public RequestController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            if (User.IsInRole("Administrator"))
                return RedirectToAction("GetRequests");

            if (User.IsInRole("Student"))
                return RedirectToAction("GetMyRequests");

            return View("RequestForm");
        }
        // GET: Requests
        [Authorize]
        public ActionResult SubmitRequest()
        {          
            return View("RequestForm");

        }
      
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Request request)
        {
            var user = User.Identity.GetUserId();

            if (request.Id == 0)
            {
                _context.Requests.Add(request);
            }
                _context.SaveChanges();

            ViewBag.Text = "Saved";

            return RedirectToAction("SubmitRequest");
        }

        public ActionResult GetRequests(int? page)
        {
            var requests = _context.Requests.Include(r => r.RequestStatus).OrderBy(r => r.Id).AsEnumerable();

            var pageNumber = page ?? 1;
            var _OnePageOfRequests = requests.ToPagedList(pageNumber, 2);

            ViewBag.OnePageOfRequests = _OnePageOfRequests;

            return View("ViewRequests", _OnePageOfRequests);
        }

        public ActionResult GetMyRequests()
        {
            var myRequests = _context.Requests.Where(r => r.StudentNumber == User.Identity.GetUserName()).ToList();

            return View("ViewMyRequests", myRequests);
        }

        public ActionResult ProcessRequest()
        {
            return View();
        }
    }
}