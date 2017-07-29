using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Models
{
    public class AdminAddModelViewModel
    {
        public List<Model> AllModels { get; set; }
        public Model NewModel { get; set; }
        public List<SelectListItem> Makes { get; set; }
    }
}