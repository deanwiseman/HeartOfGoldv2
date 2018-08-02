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
        [Authorize]
        public ActionResult SubmitRequest()
        {
            return View("RequestForm");
        }

        [Authorize(Roles = Roles.Student)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Request request)
        {

                _context.Requests.Add(request);
                _context.SaveChanges();

            ViewBag.Text = "Saved";
            
            return View("RequestForm");
        }
    }
}