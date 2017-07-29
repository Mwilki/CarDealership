using CarDealership.Data.Interfaces;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Controllers
{
    public class HomeController : Controller
    {
        private static IRepository _repo;

        public HomeController(IRepository repo)
        {
            _repo = repo;
        }
        public ActionResult Index()
        {
            return View(_repo.GetAllFeatured());
        }

        public ActionResult Specials()
        {
            var model = _repo.GetSpecials();
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";
            Contact model = new Contact();

            return View(model);
        }

        [AcceptVerbs("POST")]
        public ActionResult AddContact(Contact data)
        {
            _repo.AddContactDetails(data);
            return RedirectToAction("Index", "Home");
        }
    }
}