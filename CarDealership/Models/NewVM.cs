using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class NewVM
    {
        public string Search { get; set; }
        public int PriceLow { get; set; }
        public int PriceHigh { get; set; }
        public int YearLow { get; set; }
        public int YearHigh { get; set; }
    }
}