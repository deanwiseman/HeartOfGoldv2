using HeartOfGold.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeartOfGold.Controllers
{
    public class DonorsController : Controller
    {

        private ApplicationDbContext _context;

        public DonorsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Donors
        public ActionResult Index()
        {
            var donors = _context.Donors.ToList();

            return View(donors);
        }
    }
}