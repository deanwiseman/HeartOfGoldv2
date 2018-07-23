using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeartOfGold.Models;
using HeartOfGold.ViewModels;
using System.Data.Entity;

namespace HeartOfGold.Controllers
{
    
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

        // GET all donated items in the database
        public ActionResult Index()
        {
            var items = _context.Items.Include(i => i.Category)
                .Include(i => i.Donor)
                .ToList();

            return View(items);
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
            ViewBag.Text = "New";

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
                }

                _context.SaveChanges();

                return RedirectToAction("Index", "Item");           
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Text = "Edit";

            var item = _context.Items.SingleOrDefault(i => i.Id == id);

            if (item == null)
                return HttpNotFound();

            var viewModel = new ItemFormViewModel
            {
                Item = item,
                Categories = _context.ItemCategory.ToList(),
                Donors = _context.Donors.ToList()

            };

            return View("ItemForm", viewModel);
        }
    }
}