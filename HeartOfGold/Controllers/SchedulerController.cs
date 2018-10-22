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

        // Fetch events from db in json format
        [Authorize(Roles = Roles.Administrator)]
        public JsonResult GetEvents()
        {
            var events = _context.Events.ToList();
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        [Authorize(Roles = Roles.Administrator)]
        public JsonResult SaveEvent(Event TheEvent)
        {
            bool status = false;

            if(TheEvent.EventID > 0)
            {
                // Update the event
                var temp = _context.Events.Where(e => e.EventID == TheEvent.EventID).FirstOrDefault();
                if (temp != null)
                {
                    temp.Subject = TheEvent.Subject;
                    temp.Start = TheEvent.Start;
                    temp.End = TheEvent.End;
                    temp.Description = TheEvent.Description;
                    temp.ThemeColour = TheEvent.ThemeColour;
                }
            }
            else
            {
                // Else, add event to the database.
                _context.Events.Add(TheEvent);
            }
            _context.SaveChanges();
            status = true;

            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            bool status = false;

            var temp = _context.Events.Where(a => a.EventID == eventID).FirstOrDefault();

            if (temp != null)
            {
                _context.Events.Remove(temp);
                _context.SaveChanges();
                status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }
    }
}