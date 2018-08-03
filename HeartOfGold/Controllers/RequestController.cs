using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeartOfGold.Models;

namespace HeartOfGold.Controllers
{
    public class RequestController : Controller
    {
        private ApplicationDbContext _context;

        public RequestController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Request
        [Authorize(Roles = Roles.Student)]
        [Authorize]
        public ActionResult SubmitRequest()
        {
            return View("RequestForm");
        }

        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Request request)
        {
            if (request.Id == 0)
            {
                _context.Requests.Add(request);
            }
                _context.SaveChanges();

            ViewBag.Text = "Saved";

            return RedirectToAction("SubmitRequest");
        }
    }
}