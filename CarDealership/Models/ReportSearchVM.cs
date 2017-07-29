using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class ReportSearchVM
    {
        public List<AppUser> Users { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}