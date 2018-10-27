using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeartOfGold.Models;

namespace HeartOfGold.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

        public void SendEmail(Email email)
        {
            Mailer.GmailUsername = "heart.of.gold.mandela@gmail.com";
            Mailer.GmailPassword = "Newtonpark2525";

            Mailer mailer = new Mailer();
            mailer.ToEmail = email.ToEmail;
            mailer.Subject = email.Subject;
            mailer.Body = email.Body;
            mailer.IsHtml = true;
            mailer.Send();
        }

        public ActionResult SendDonorEmail(Email email)
        {
            Mailer.GmailUsername = "heart.of.gold.mandela@gmail.com";
            Mailer.GmailPassword = "Newtonpark2525";

            Mailer mailer = new Mailer();
            mailer.ToEmail = email.ToEmail;
            mailer.Subject = email.Subject;
            mailer.Body = email.Body;
            mailer.IsHtml = true;
            mailer.Send();

            // Set arbitrary value into TempData for use in displaying toastr notifcation
            TempData["Emailed"] = "Emailed";

            return RedirectToAction("Index", "Donors");
        }
    }
}