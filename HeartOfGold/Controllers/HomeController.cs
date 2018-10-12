using System.Linq;
using System.Web.Mvc;
using HeartOfGold.Models;
using HeartOfGold.ViewModels;

namespace HeartOfGold.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = Roles.Administrator)]
        public ViewResult Dashboard()
        {
            // Total number of oustanding requests.
            var OutstandingRequests = _context.Requests.Where(r => r.RequestStatusId == 1).Count();

            // Number of registered students, -1 to exclude administrator user.
            var NumStudents = _context.Users.Count() - 1;

            // check if not inactive
            var ClothesItemsCount = _context.Items.Where(i => i.CategoryId == 1)
                .Where(i => i.IsActive == true)
                .Sum(i => i.Quantity);

            var TextBooksCount = _context.Items.Where(i => i.CategoryId == 2)
                .Where(i => i.IsActive == true)
                .Sum(i => i.Quantity);

            var StationeryItemsCount = _context.Items.Where(i => i.CategoryId == 3)
                .Where(i => i.IsActive == true)
                .Sum(i => i.Quantity);

            var FoodItemsCount = _context.Items.Where(i => i.CategoryId == 4)
                .Where(i => i.IsActive == true)
                .Sum(i => i.Quantity);

            var OtherItemsCount = _context.Items.Where(i => i.CategoryId == 5)
                .Where(i => i.IsActive == true)
                .Sum(i => i.Quantity);          

            var viewModel = new DashboardViewModel
            {
                OutstandingStudentRequests = OutstandingRequests,
                NumberOfStudents = NumStudents,
                TotalClothesItems = ClothesItemsCount,
                TotalTextbookItems = TextBooksCount,
                TotalStationeryItems = StationeryItemsCount,
                TotalFoodItems = FoodItemsCount,
                TotalOtherItems = OtherItemsCount
            };

            return View(viewModel);
        }
    }
}