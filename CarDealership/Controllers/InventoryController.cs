using CarDealership.Data.Interfaces;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CarDealership.Controllers
{
    public class InventoryController : Controller
    {

        private IRepository _repo;


        public InventoryController(IRepository repo)
        {
            _repo = repo;
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult NewSearch(NewVM data)
        {
            string term = "";
            if (data.Search != null)
            {
                term = data.Search.ToUpper();
            }
            int priceLow = data.PriceLow;
            int priceHigh = data.PriceHigh;
            int yearLow = data.YearLow;
            int yearHigh = data.YearHigh;
            List<Vehicle> model = _repo.GetAllNewVehicles(term, priceHigh, priceLow, yearLow, yearHigh);
            return View(model);
        }

        public ActionResult Used()
        {
            return View();
        }

        public ActionResult UsedSearch(UsedVM data)
        {
            string term = "";
            if (data.Search != null)
            {
                term = data.Search.ToUpper();
            }
            int priceLow = data.PriceLow;
            int priceHigh = data.PriceHigh;
            int yearLow = data.YearLow;
            int yearHigh = data.YearHigh;
            List<Vehicle> model = _repo.GetAllUsedVehicles(term, priceHigh, priceLow, yearLow, yearHigh);
            return View(model);
        }

        [System.Web.Http.Route("{id}")]
        public ActionResult Details(int id)
        {
            var model = _repo.GetVehicleById(id);
            return View(model);
        }
    }
}