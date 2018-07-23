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
        // GET: Request
        public ActionResult SubmitRequest()
        {
            return View("RequestForm");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Request request)
        {


            return View("RequestForm");
        }
    }
}