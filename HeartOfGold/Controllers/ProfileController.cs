using System.Linq;
using System.Web.Mvc;
using HeartOfGold.ViewModels;
using HeartOfGold.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

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
        [Authorize(Roles = Roles.Student)]
        public ActionResult Index()
        {
            var name = User.Identity.Name;
            var StudentNumber = name.Remove(0, 1);
            var id = User.Identity.GetUserId();

            var studentRequests = _context.Requests
                .Include(r => r.RequestStatus)
                .Where(r => r.StudentNumber == StudentNumber)
                .ToList();

            if (studentRequests.Count == 0)
            {
                TempData["NoResults"] = "No Results.";
            }

            var _Student = _context.Users.Where(r => r.Id == id).First();
            var _Categories = _context.ItemCategory.ToList();

            var viewModel = new ProfileViewModel
            {
                Requests = studentRequests,
                Name = _Student.FirstName,
                Surname = _Student.Surname,
                Email = _Student.Email,
                Categories = _Categories             
            };

            return View(viewModel);
        }
    }
}