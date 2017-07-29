using CarDealership.Data.Interfaces;
using CarDealership.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Controllers
{
    public class SalesController : Controller
    {

        private IRepository _repo;

        public SalesController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs("POST")]
        public ActionResult SearchInStock(NewVM data)
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
            List<Vehicle> model = _repo.GetVehiclesInStock(term, priceHigh, priceLow, yearLow, yearHigh);
            return View(model);
        }

        // GET: Sales/Details/5
        public ActionResult PurchaseVehicle(int id)
        {
            var vm = new SalesVehicleViewModel();
            vm.Vehicle = _repo.GetVehicleById(id);
            return View(vm);
        } 

        [AcceptVerbs("POST")]
        public ActionResult PurchaseVehicle(SalesVehicleViewModel purchase)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("salesperson"))
            {
                var salesPersonId = User.Identity.GetUserId();
                var allocatesale = purchase.Sale.SaleId.ToString();
                var model = _repo.GetVehicleById(purchase.Vehicle.Id);

                allocatesale = salesPersonId;
                _repo.VehicleOutOfStock(purchase.Vehicle.Id);
                _repo.MakePurchase(allocatesale, purchase.Sale, model);

            }
            return RedirectToAction("Index", "Sales");
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sales/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sales/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sales/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
