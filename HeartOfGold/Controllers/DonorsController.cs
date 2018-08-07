using HeartOfGold.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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

        public ActionResult History(int id)
        {
            var donorName = _context.Donors.Single(d => d.Id == id);

            ViewBag.Donor = donorName.FullName;

            var donationHistoryData = _context.Items.Include(i => i.Category)
                .Include(i => i.Donor)
                .Where(i => i.DonorId == id)
                .ToList();


            return View("History", donationHistoryData);
        }

        public ActionResult SendEmail()
        {
            Mailer.GmailUsername = "";
            Mailer.GmailPassword = "";

            Mailer mailer = new Mailer();
            mailer.ToEmail = "s212273582@mandela.ac.za";
            mailer.Subject = "Testing email from Heart of Gold...";
            mailer.Body = "Testing yo";
            mailer.IsHtml = true;
            mailer.Send();


            return RedirectToAction("Index", "Donors");
        }
    }
}