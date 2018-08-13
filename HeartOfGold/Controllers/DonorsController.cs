using HeartOfGold.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using HeartOfGold.ViewModels;

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
            var _donors = _context.Donors.ToList();

            var viewModel = new DonorViewModel
            {
                Donors = _donors
            };


            return View(viewModel);
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

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddDonor(Donor donor)
        {
            if(donor.Id == 0)
            {
                _context.Donors.Add(donor);
            }

            else
            {
                var donorInDb = _context.Donors.Single(d => d.Id == donor.Id);
                donorInDb.FirstName = donor.FirstName;
                donorInDb.LastName = donor.LastName;
                donorInDb.Email = donor.Email;       
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}