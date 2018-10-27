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
            var requestID = Session["RequestID"] as int?;
            bool status = false;

            if(TheEvent.EventID > 0)
            {
                // Update the event
                var temp = _context.Events.Where(e => e.EventID == TheEvent.EventID).FirstOrDefault();
                if (temp != null)
                {
                    // Set the updated values
                    temp.Subject = TheEvent.Subject;
                    temp.Start = TheEvent.Start;
                    temp.End = TheEvent.End;
                    temp.Description = TheEvent.Description;
                    temp.ThemeColour = TheEvent.ThemeColour;

                    if (TheEvent.RequestKey != null)
                    {
                        // Fetch the request linked to the event,
                        var currentRequest = _context.Requests.Single(r => r.Id == TheEvent.RequestKey);
                        // Update the collection date accordingly. This allows updates to the tracking of a student's own requests.
                        currentRequest.CollectionDate = TheEvent.Start;
                    }
                }
            }
            else
            {
                // Else, create a new event

                if(requestID != null)
                {
                    // Put the passed through requestID into the Event object
                    TheEvent.RequestKey = (int)requestID;

                    // Get request object where = Key/Id
                    var currentRequest = _context.Requests.Single(r => r.Id == requestID);

                    // Set that request's collectiondate to the chosen startdate in the event creation.
                    currentRequest.CollectionDate = TheEvent.Start;

                    // Update request's status to 'Awaiting Collection'
                    currentRequest.RequestStatusId = 6;
                }

                // add event to the database.
                _context.Events.Add(TheEvent);
            }

            _context.SaveChanges();
            status = true;

            return new JsonResult { Data = new { status = status } };
        }

        [Authorize]
        [HttpPost]
        public JsonResult DeleteEvent(int eventID, int RequestKey)
        {
            bool status = false;

            var currentEvent = _context.Events.Where(a => a.EventID == eventID).FirstOrDefault();

            if (currentEvent != null)
            {
                _context.Events.Remove(currentEvent);

                status = true;
            }

            if (RequestKey > 0)
            {
                var currentRequest = _context.Requests.Where(r => r.Id == RequestKey).FirstOrDefault();
                if (currentRequest != null)
                {
                    currentRequest.RequestStatusId = 4;
                }
            }

            _context.SaveChanges();

            return new JsonResult { Data = new { status = status } };
        }

    }
}