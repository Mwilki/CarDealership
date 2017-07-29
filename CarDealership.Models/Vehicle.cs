using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public string Image { get; set; }
        public bool IsNew { get; set; }
        public string BodyStyle { get; set; }
        public string Trans { get; set; }
        public string Color { get; set; }
        public string Interior { get; set; }
        public int? Mileage { get; set; }
        public string VinNumber { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MSRP { get; set; }
        public string Description { get; set; }
        public bool InStock { get; set; }
        public bool IsFeatured { get; set; }
    }
}
