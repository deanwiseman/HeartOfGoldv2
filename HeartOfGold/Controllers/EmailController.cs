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

        public ActionResult SendEmail(Email email)
        {
            Mailer.GmailUsername = "";
            Mailer.GmailPassword = "";

            Mailer mailer = new Mailer();
            mailer.ToEmail = email.ToEmail;
            mailer.Subject = email.Subject;
            mailer.Body = email.Body;
            mailer.IsHtml = true;
            mailer.Send();

            return RedirectToAction("Dashboard", "Home");
        }
    }
}