using HeartOfGold.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeartOfGold.ViewModels;
using System.Data.Entity;

namespace HeartOfGold.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext _context;

        public StudentController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Current()
        {
            var students = _context.Users.ToList();
            var queryResults = from s in students where s.UserName.StartsWith("s") select s;

            var viewModel = new StudentViewModel
            {
                Users = queryResults
            };

            return View(viewModel);
        }
    }
}