using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Models
{
    public class AdminSpecialsViewModel
    {
        public List<Special> CurrentSpecials { get; set; }
        public Special NewSpecial { get; set; }


        public AdminSpecialsViewModel(List<Special> currentspecials)
        {
            CurrentSpecials = currentspecials;
            NewSpecial = new Special();
        }

        public AdminSpecialsViewModel()
        {
            NewSpecial = new Special();
        }
    }
}