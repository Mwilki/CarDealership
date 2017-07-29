using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class InventoryReportVM
    {
        public bool New { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public string Make { get; set; }
        public decimal StockValue { get; set; }
        public int Count { get; set; }
    }
}