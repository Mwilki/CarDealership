using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Models
{
    public class AdminAddVehicleViewModel
    {
        public Vehicle Vehicle { get; set; }
        public List<SelectListItem> AllMakes { get; set; }
        public List<SelectListItem> AllModels { get; set; }
        public List<SelectListItem> AllBodyStyles { get; set; }
        public List<SelectListItem> AllColors { get; set; }
        public List<SelectListItem> AllTransmissions { get; set; }
        public List<SelectListItem> AllInteriors { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}