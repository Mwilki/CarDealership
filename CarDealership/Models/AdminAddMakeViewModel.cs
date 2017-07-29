using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class AdminAddMakeViewModel
    {
        public List<Make> AllMakes { get; set; }
        public Make NewMake { get; set; }
    }
}