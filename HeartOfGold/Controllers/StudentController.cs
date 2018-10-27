using HeartOfGold.Models;
using System.Linq;
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

        [Authorize(Roles = Roles.Administrator)]
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

        [Authorize(Roles = Roles.Administrator)]
        public ActionResult ViewStudentRequests(string studentNumber)
        {

            var requests = _context.Requests.Include(r => r.RequestStatus)
                .Include(r => r.Category)
                .Where(r => r.StudentNumber == studentNumber)
                .OrderByDescending(r => r.Id)
                .ToList();

            var viewModel = new StudentRequestsViewModel
            {
                Requests = requests
            };


            return View("Requests", viewModel);
        }
    }
}