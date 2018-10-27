using System;
using System.Linq;
using System.Web.Mvc;
using HeartOfGold.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using PagedList;
using HeartOfGold.ViewModels;

namespace HeartOfGold.Controllers
{
    public class RequestController : Controller
    {
        private ApplicationDbContext _context;

        public RequestController()
        {
            _context = new ApplicationDbContext();
        }
        
        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Administrator"))
                return RedirectToAction("GetRequests");

            if (User.IsInRole("Student"))
                return RedirectToAction("GetMyRequests");

            return View("RequestForm");
        }

        // GET: Requests
        [Authorize(Roles = Roles.Student)]
        public ActionResult SubmitRequest()
        {
            // Business rule: a student may only have 3 total requests at one point in time. Check against this first:
            if (CanSubmitRequest())
            {
                var Categories = _context.ItemCategory.ToList();

                var viewModel = new RequestFormViewModel
                {
                    RequestCategories = Categories
                };

                return View("RequestForm", viewModel);

            }
            else
            {
                // add entry to TempData for use in displaying notification (with toastr)
                TempData["RequestLimit"] = "Invalid request.";
                return RedirectToAction("Index", "Home");
            }           
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

            TempData["Saved"] = "Saved";

            return RedirectToAction("SubmitRequest");
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult GetRequests(int? page, string searchString, int? StatusFilter)
        {
            // Get all requests that are currently of 'Open' status.
            var requests = _context.Requests.Include(r => r.RequestStatus)
                .Where(r => r.RequestStatusId == 1)
                .OrderBy(r => r.Id)
                .AsEnumerable();

            if(StatusFilter != null)
            {
                if(StatusFilter == 1)
                {
                     requests = _context.Requests.Include(r => r.RequestStatus)
                    .Where(r => r.RequestStatusId == 1)
                    .OrderBy(r => r.Id)
                    .AsEnumerable();
                }
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                requests = requests.Where(s => s.StudentNumber.Contains(searchString));

                if (requests.Count() == 0)
                {
                    ViewBag.Results = "Nothing";
                }
                else
                {
                    if (searchString.Length > 10)
                    {
                        ViewBag.HasResults = null;
                    }
                    else
                    {
                        int countResults = requests.Count();

                        if (countResults > 1)
                            ViewBag.HasResults = "Showing " + requests.Count() + " results for '" + searchString + "'... ";
                        else
                            ViewBag.HasResults = "Showing 1 result for '" + searchString + "'...";
                    }
                }
            }

            if (requests.Count() == 0)
                ViewBag.HasResults = "There are no outstanding student requests at this point.";

            var pageNumber = page ?? 1;
            var _OnePageOfRequests = requests.ToPagedList(pageNumber, 1);

            ViewBag.OnePageOfRequests = _OnePageOfRequests;

            return View("ViewRequests", _OnePageOfRequests);
        }

        [HttpPost]
        public ActionResult ProcessRequest(Request request)
        {
            // Fetch current request from db,
            var requestInDb = _context.Requests.Single(r => r.Id == request.Id);

            if(Session["Donation"] != null)
            {
                requestInDb.AllocatedDonationItem = Session["Donation"].ToString();
            }           

            // Set its status to the one the user decides
            requestInDb.RequestStatusId = request.SelectedStatusId;

            _context.SaveChanges();

            // If the request was marked as successful, redirect to Scheduler in order to create an event
            if(request.SelectedStatusId == 2)
            {
                // Put requestID of current request into session variable -> subsequent controller
                Session["RequestID"] = request.Id;

                return RedirectToAction("Index", "Scheduler");
            }

            // Else just redirect to current Index
            return RedirectToAction("Index");
            
        }

        public bool CanSubmitRequest()
        {
            // fetch student number of currently logged in student
            var name = User.Identity.Name;
            var StudentNumber = name.Remove(0, 1);

            // count number of requests with 'open' status
            var RequestCount = _context.Requests
                .Where(r => r.StudentNumber == StudentNumber)
                .Where(r => r.RequestStatusId == 1)
                .Count();
            return RequestCount < 3 ? true : false;
        }
    }
}