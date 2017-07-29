using CarDealership.Data;
using CarDealership.Data.Interfaces;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealershipMastery.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class ReportsController : Controller
    {
        private IRepository _repo;

        public ReportsController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SalesReport()
        {
            var model = _repo.GetStatistics();
            return View(model);
        }

        public ActionResult InventoryReport()
        {
            decimal stockValue = 0;

            int count = 0;

            List<InventoryReportVM> model = new List<InventoryReportVM>();

            var inStock = _repo.GetAllVehicles().Where(v => v.InStock == true).ToList();

            var inv = inStock.GroupBy(v => new { v.IsNew, v.Make, v.Model, v.Year });

            foreach (var vehicle in inv)

            {
                InventoryReportVM singleModel = new InventoryReportVM();
                singleModel.New = vehicle.Key.IsNew;   
                singleModel.Model = vehicle.Key.Model;
                singleModel.Year = vehicle.Key.Year;
                singleModel.Make = vehicle.Key.Make;

                foreach (var s in vehicle)
                {
                    stockValue += s.MSRP;
                    count++;
                }
                singleModel.StockValue = stockValue;
                singleModel.Count = count;
                model.Add(singleModel);
            }
            return View(model);
        }
    }
}