using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using HeartOfGold.ViewModels;
using HeartOfGold.Models;
using Newtonsoft.Json;

namespace HeartOfGold.Controllers
{
    public class ReportsController : Controller
    {
        private ApplicationDbContext _context;

        public ReportsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Reports
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult GetChartData()
        {
            List<ChartViewModel> ChartData = new List<ChartViewModel>();

            var data = _context.Items.ToList();

            foreach(Item Current in data)
            {
                ChartViewModel chartVm = new ChartViewModel();
                chartVm.Quantity = Current.Quantity;
                chartVm.Month = Current.DateAdded.ToString("MMMM");
                ChartData.Add(chartVm);
            }

            return Content(JsonConvert.SerializeObject(ChartData), "application/json");
        }
    }
}