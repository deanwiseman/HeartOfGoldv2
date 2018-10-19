using HeartOfGold.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using HeartOfGold.ViewModels;

namespace HeartOfGold.Controllers
{
    public class SchedulerController : Controller
    {
        private ApplicationDbContext _context;

        public SchedulerController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Scheduler
        public ActionResult Index()
        {

            return View();
        }
    }
}