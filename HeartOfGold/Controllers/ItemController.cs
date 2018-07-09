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
            var itemCategories = _context.ItemCategory.ToList();
            var donors = _context.Donors.ToList();

            var viewModel = new NewItemViewModel
            {
                Categories = itemCategories,
                Donors = donors
            };

            return View("New", viewModel);
        }

        // Create a new item.
        [HttpPost]
        public ActionResult Create(Item item)
        {
            if (item.Id == 0)
                _context.Items.Add(item);
            else
            {
                var itemInDb = _context.Items.Single(i => i.Id == item.Id);
                itemInDb.Name = item.Name;
                itemInDb.Description = item.Description;
                itemInDb.Quantity = item.Quantity;
                itemInDb.Donor = item.Donor;
                itemInDb.Category = item.Category;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Item");
        }

        public ActionResult Edit(int id)
        {
            var item = _context.Items.SingleOrDefault(i => i.Id == id);

            if (item == null)
                return HttpNotFound();

            return View(item);
        }
    }
}