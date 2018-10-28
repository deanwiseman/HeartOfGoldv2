using HeartOfGold.Models;
using System.Linq;
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
            var donor = _context.Donors.Single(d => d.Id == id);

            ViewBag.Donor = donor.FullName;

            var donationHistoryData = _context.Items.Include(i => i.Category)
                .Include(i => i.Donor)
                .Where(i => i.DonorId == id)
                .Where(i => i.IsActive == true)
                .ToList();

            var viewModel = new DonorHistoryViewModel
            {
                Donations = donationHistoryData,
                Donor = donor
            };

            return View("History", viewModel);
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
                TempData["Saved"] = "Saved";
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


        [HttpPost]
        public JsonResult DeleteDonor(int DonorID)
        {
            bool status = false;
            var temp = _context.Donors.Where(a => a.Id == DonorID).FirstOrDefault();

            if (temp != null)
            {
                _context.Donors.Remove(temp);
                _context.SaveChanges();
                status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }

        [Authorize(Roles = Roles.Administrator)]
        public JsonResult GetEmail(int DonorID)
        {
            var emailAddress = _context.Donors.Where(d => d.Id == DonorID).Select(d => d.Email).Single();

            return new JsonResult { Data = emailAddress, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}