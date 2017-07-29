using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Statistic
    {
        public int StatisticId { get; set; }
        public string SalesPerson { get; set; }
        public decimal? TotalSales { get; set; }
        public int VehiclesSold { get; set; }
    }
}
