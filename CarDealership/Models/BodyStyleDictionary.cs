using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Models
{
    public class BodyStyleDictionary
    {
        public SelectList BodyStyleSelectList
        {
            get { return new SelectList(AllBodystyles, "Value", "Key"); }
        }
        public static readonly IDictionary<string, string>
            AllBodystyles = new Dictionary<string, string> {
                //this needs to be a storedproc on the db to get all the unique bodystyles in inventory table
                { "Sedan","Sedan" },
                { "Sport 2-door","Sport 2-door" },
                { "Coupe","Coupe" },
                { "Hatchback","Hatchback" },
                {"Truck","Truck" }
            };
    }
}