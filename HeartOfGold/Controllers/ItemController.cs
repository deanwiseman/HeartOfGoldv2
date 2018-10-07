using System.Linq;
using System.Web.Mvc;
using HeartOfGold.Models;
using HeartOfGold.ViewModels;
using System.Data.Entity;

namespace HeartOfGold.Controllers
{
    // This entire controller, working with donations, is only accessible to the administrator user.
    [Authorize(Roles = Roles.Administrator)]
    public class ItemController : Controller
    {
        private ApplicationDbContext _context;

        public ItemController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET all donated items in the database (that have not been soft-deleted. See: IsActive property)
        public ActionResult Index()
        {
            var items = _context.Items.Include(i => i.Category)
                .Include(i => i.Donor)
                .Where(i => i.IsActive == true)
                .ToList();

            var viewModel = new InventoryViewModel
            {
                Donations = items
            };

            return View(viewModel);
        }

        public ActionResult GetRemoved()
        {
            var items = _context.Items.Include(i => i.Category)
                .Include(i => i.Donor)
                .Where(i => i.IsActive == false)
                .ToList();

            var viewModel = new InventoryViewModel
            {
                Donations = items
            };

            return Json(items, JsonRequestBehavior.AllowGet);
            //return View("Index", viewModel);
        }


        //View a single item in more detail
        public ActionResult Details(int id)
        {
            var item = _context.Items.Include(i => i.Category).SingleOrDefault(i => i.Id == id);

            if (item == null)
                return HttpNotFound();

            return View(item);
        }
       
        public ActionResult New()
        {
            var itemCategories = _context.ItemCategory.ToList();
            var donors = _context.Donors.ToList();

            var viewModel = new ItemFormViewModel
            {
                Categories = itemCategories,
                Donors = donors
            };

            return View("ItemForm", viewModel);
        }

        // Save or update a donation item.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Item item)
        {
            //if (!ModelState.IsValid)
            //{
            //    var viewModel = new ItemFormViewModel
            //    {
            //        Item = item,
            //        Categories = _context.ItemCategory.ToList(),
            //        Donors = _context.Donors.ToList()

            //    };

            //    return View("ItemForm", viewModel);
            //}

            // If item doesn't exist, add it
            if (item.Id == 0)
                {
                    _context.Items.Add(item);
                    TempData["Saved"] = "Saved";
                }
                // Else, update it
                else
                {
                    var itemInDb = _context.Items.Single(c => c.Id == item.Id);
                    itemInDb.Name = item.Name;
                    itemInDb.Description = item.Description;
                    itemInDb.Quantity = item.Quantity;
                    itemInDb.CategoryId = item.CategoryId;
                    itemInDb.DonorId = item.DonorId;
                    TempData["Updated"] = "Updated";

                // Soft-delete donation.
                if (item.MustDelete == true)
                    itemInDb.IsActive = false;
                    TempData["Deleted"] = "Deleted";
                }

                _context.SaveChanges();
            

            return RedirectToAction("Index");         
        }

        public ActionResult Edit(int id)
        {
            var item = _context.Items.SingleOrDefault(i => i.Id == id);

            if (item == null)
                return HttpNotFound();

            var viewModel = new ItemFormViewModel
            {
                Item = item,
                Categories = _context.ItemCategory.ToList(),
                Donors = _context.Donors.ToList()

            };

            return View("Edit", viewModel);
        }      
    }
}