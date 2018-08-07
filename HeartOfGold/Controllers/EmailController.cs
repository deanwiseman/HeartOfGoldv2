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

        public ActionResult SendEmail()
        {
            Mailer.GmailUsername = "heart.of.gold.mandela@gmail.com";
            Mailer.GmailPassword = "Newtonpark2525";

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