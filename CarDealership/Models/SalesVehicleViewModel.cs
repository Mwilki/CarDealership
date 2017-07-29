using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class SalesVehicleViewModel
    {
        public Vehicle Vehicle { get; set; }
        public Sale Sale { get; set; }
        public StatesDictionary States { get; set; }
        public PurchaseTypeList PurchaseTypes { get; set; }

        public SalesVehicleViewModel()
        {
            PurchaseTypes = new PurchaseTypeList();
            States = new StatesDictionary();
            Sale = new Sale();
        }
    }
}