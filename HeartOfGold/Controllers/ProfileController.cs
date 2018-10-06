using System.Linq;
using System.Web.Mvc;
using HeartOfGold.ViewModels;
using HeartOfGold.Models;
using Microsoft.AspNet.Identity;

namespace HeartOfGold.Controllers
{
    public class ProfileController : Controller
    {
        private ApplicationDbContext _context;

        public ProfileController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Profile
        [Authorize]
        public ActionResult Index()
        {
            var dsf = User.Identity.GetUserName();
            var name = User.Identity.Name;
            var StudentNumber = name.Remove(0, 1);
            var id = User.Identity.GetUserId();
             

            var studentRequests = _context.Requests.Where(r => r.StudentNumber == StudentNumber).ToList();
            var Student = _context.Users.Where(r => r.Id == id).First();

            var viewModel = new ProfileViewModel
            {
                Requests = studentRequests,
                Name = Student.FirstName,
                Surname = Student.Surname,
                Email = Student.Email
               
            };

            return View(viewModel);
        }
    }
}